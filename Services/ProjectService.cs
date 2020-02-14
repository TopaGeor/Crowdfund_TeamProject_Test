using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using System;
using System.Linq;

namespace Crowdfund.Core.Services
{
    class ProjectService : IProjectService
    {
        private readonly ICreatorService creator_;
        private readonly IBackerService backers_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public ProjectService(
           ICreatorService creator,
           BackerService backers,
           Crowdfund_TeamProjectDbContext context)
        {
            creator_ = creator;
            context_ = context;
            backers_ = backers;
        }


        public Project CreateProject(int creatorId, AddProjectOptions options)
        {
            if(options == null) {
                return null;
            }

            if(creatorId <= 0) {
                return null;
            }

            var creator = creator_.SearchCreator(
               new SearchCreatorOptions()
               {
                   Id = creatorId
               }).SingleOrDefault();

            if(creator == null) {
                return null;
            }
            if (string.IsNullOrWhiteSpace(options.Title)) {
                return null;
            }

            var exist = SearchProject(
                new SearchProjectOptions(){
                    Title = options.Title
                }).Any();
            if (exist) {
                return null;
            }

            if(options.TiersId == null ||
              options.TiersId.Count == 0) {
                return null;
            }

           var  tiers = context_
                .Set<Tier>()
                .Where(t => options.TiersId.Contains(t.Id))
                .ToList();

            if (tiers.Count != options.TiersId.Count) {
                return null;
            }

            if (options.Goal <= 0.00M) {
                return null;
            }

            if (options.Photo.Count > 0) {
                foreach (var p in options.Photo) {
                    if (string.IsNullOrWhiteSpace(p)) {
                        return null;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return null;
            }

            if (options.Video.Count > 0) {
                foreach (var v in options.Video) {
                    if (string.IsNullOrWhiteSpace(v)) {
                        return null;
                    }
                }
            }

            if(options.Category == ProjectCategory.Invalid) {
                return null;
            }

            var newProj = new Project() {
                Description = options.Description,
                Title = options.Title,
                Creator = creator,
                Category = options.Category,
                Status = ProjectStatus.Running,
                Goal = options.Goal,
                Photos = options.Photo,
                Videos = options.Video
            };

            foreach (var t in tiers) {
                newProj.Tiers.Add(t);
                   }

            context_.Add(newProj);
            try {
                context_.SaveChanges();
            } catch (Exception) {
                return null;
            }

            return newProj;
        }

    

        public IQueryable<Project> SearchProject(SearchProjectOptions options)
        {
            
            if(options == null) {
                return null;
            }
            var query = context_
                .Set<Project>()
                .AsQueryable();

            if (options.Id >0 ) {
                query = query
                     .Where(p => p.Id == options.Id);
            }

            if (!string.IsNullOrWhiteSpace(options.Title)) {
                query = query
                    .Where(p => p.Title == options.Title);
            }
            var creator = creator_.SearchCreator(
                new SearchCreatorOptions()
                {
                    Id = options.Creator.Id
                }).SingleOrDefault();

            if(creator != null) {
                query = query
                    .Where(p => p.Creator == creator);
            }

            if(options.Category != ProjectCategory.Invalid) {
                query = query
                    .Where(p => p.Category == options.Category);
            }

            if(options.Status == ProjectStatus.Running) {
                query = query
                    .Where(p => p.Status == options.Status);
            }

            return query.Take(500);
        }

        public bool UpdateProject(int Projectid, UpdateProjectOptions options)
        {
            if (options == null) {
                return false;
            }

            if (Projectid <= 0) {
                return false;
            }

            var project = SearchProject(
                new SearchProjectOptions(){
                 Id = Projectid})
                .SingleOrDefault();

            if (project == null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.Description)) {
                project.Description = options.Description;
            }
            foreach (var p in options.Photo) {
                if (string.IsNullOrWhiteSpace(p)) {
                    project.Photos.Add(p);
                }
            }
            foreach (var v in options.Video) {
                if (string.IsNullOrWhiteSpace(v)) {
                    project.Videos.Add(v);
                }
            }
        
            if(options.Status != ProjectStatus.Invalid) {
                project.Status = options.Status;
            }

            return true;
        }
    }
}
