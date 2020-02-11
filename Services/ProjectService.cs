using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace TinyCrm.Core.Services
{
    class ProjectService : IProjectService
    {
        public UserService userService = new UserService();
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

            if (string.IsNullOrWhiteSpace(options.Photo)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Video)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Title)) {
                return false;
            }

            var creator = userService.SearchByUser(
                new SearchUserOptions()
                {
                    Id = options.Creator.Id
                });

            if(creator == null) {
                return false;
            }

            if(options.Status != ProjectStatus.Running) {
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
                Category= options.Category,
                Status = ProjectStatus.Running,
                Goal = options.Goal
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

            var creator = userService.SearchByUser(
                new SearchUserOptions()
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
           if(options == null) {
                return false;
            }

           if(id <= 0) {
                return false;
            }

            var proj = SearchProject(
                new SearchProjectOptions()
                {
                    Id = id
                }).SingleOrDefault();
            
            if(proj == null) {
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(options.Description)) {
                proj.Description = options.Description;
            }
            
            if (string.IsNullOrWhiteSpace(options.Photo)) {
                proj.Photos.Add(options.Photo);
            }
            
            if (string.IsNullOrWhiteSpace(options.Video)) {
                proj.Videos.Add(options.Video);
            }
            
            if(options.Status != ProjectStatus.Invalid) {
                proj.Status = options.Status;
            }
            
            return true;
        }
    }
}
