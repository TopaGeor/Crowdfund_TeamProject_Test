using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
    class ProjectService : IProjectService
    {
        public ICreatorService CrService = new CreatorService();

        public  IBackerService BrService = new BackerService();


        ICollection<Project> ProjectsList = new List<Project>();
        public bool CreateProject(AddProjectOptions options)
        {
            if(options == null) {
                return false;
            }

            if(options.Id <= 0) {
                return false;
            }

            if (ProjectsList.Where(p => p.Id == options.Id) != null) {
                return false;
            }

            if (options.Goal <= 0.00M) {
                return false;
            }

            foreach (var p in options.Photo) {
                if (string.IsNullOrWhiteSpace(p)) {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return false;
            }
            foreach (var v in options.Video) {
                if (string.IsNullOrWhiteSpace(v)) {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(options.Title)) {
                return false;
            }
            var creator = CrService.SearchCreator(
                new SearchCreatorOptions()
                {
                    Id = options.Creator.Id
                });

            if(creator == null) {
                return false;
            }

            if(options.Category == ProjectCategory.Invalid) {
                return false;
            }

            var newProj = new Project() {
                Id = options.Id,
                Description = options.Description,
                Title = options.Title,
                Creator = creator.SingleOrDefault(),
                Category = options.Category,
                Status = ProjectStatus.Running,
                Goal = options.Goal,
                Photos = options.Photo,
                Videos = options.Video
                };


            if (ProjectsList.Contains(newProj)) {
                return false;
            }
            ProjectsList.Add(newProj);
            return true;
        }

    

        public ICollection<Project> SearchProject(SearchProjectOptions options)
        {
            var result = ProjectsList.Take(100);
            if(options == null) {
                return null;
            }

            if(options.Id >0 ) {
                result = ProjectsList
                    .Where(p => p.Id == options.Id);  
            }

            if (!string.IsNullOrWhiteSpace(options.Title)) {
                result = ProjectsList.Where(p => p.Title == options.Title);
            }
            var creator = CrService.SearchCreator(
                new SearchCreatorOptions()
                {
                    Id = options.Creator.Id
                }
                );

            if(creator != null) {
                result = ProjectsList.Where(p => p.Creator == options.Creator);
            }

            if(options.Category != ProjectCategory.Invalid) {
                result = ProjectsList.Where(p => p.Category == options.Category);
            }

            if(options.Status == ProjectStatus.Running) {
                result = ProjectsList.Where(p => p.Status == options.Status);
            }

            return result.ToList();
        }

        public bool UpdateProject(int id, UpdateProjectOptions options)
        {
            if (options == null) {
                return false;
            }

            if (id <= 0) {
                return false;
            }

            var proj = SearchProject(
                new SearchProjectOptions()
                {
                    Id = id
                }).SingleOrDefault();
            if (proj == null) {
                return false;
            }
            if (string.IsNullOrWhiteSpace(options.Description)) {
                proj.Description = options.Description;
            }
            foreach (var p in options.Photo) {
                if (string.IsNullOrWhiteSpace(p)) {
                    proj.Photos.Add(p);
                }
            }
            foreach (var v in options.Video) {
                if (string.IsNullOrWhiteSpace(v)) {
                    proj.Videos.Add(v);
                }
            }
        
            if(options.Status != ProjectStatus.Invalid) {
                proj.Status = options.Status;
            }

            return true;
        }
    }
}
