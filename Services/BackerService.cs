using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Model;

namespace Crowdfund.Core.Services
{
    public class BackerService : IBackerService
    {
        ICollection<Backer> BackersList = new List<Backer>();

        ICollection<Project> ProjectList = new List<Project>();

        IProjectService Project = new ProjectService();

        public bool AddBacker(AddCBackerOptions options)
        {
            if (options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Password)) {
                return false;
            }

            var exist = SearchBacker(
                new SearchBackerOptions()
                {
                    Email = options.Email
                }).Any();

            if (exist) {
                return false;
            }

            var newBacker = new Backer()
            {
                Email = options.Email,
                Name = options.Name,
                Password = options.Password
            };

            if (BackersList.Contains(newBacker)) {
                return false;
            }

            BackersList.Add(newBacker);
            return true;

        }

        public ICollection<Backer> SearchBacker(SearchBackerOptions options)
        {
            var result = BackersList.Take(100);

            if (options == null) {
                return null;
            }
            if (options.Id != 0 && options.Id > 0) {
                result = BackersList.Where(u => u.Id == options.Id);
            }
            if (string.IsNullOrWhiteSpace(options.Name)) {
                result = BackersList.Where(u => u.Name == options.Name);
            }
            if (string.IsNullOrWhiteSpace(options.Email)) {
                result = BackersList.Where(u => u.Email == options.Email);
            }
            return result.ToList();
        }

        public bool UpdateBacker(int id, UpdateBackerOptions options)
        {
            if(options == null) {
                return false;
            }
            if (id <= 0) {
                return false;
            }
            var user = GetBackerById(id);

            if (user == null) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.Password)) {
                user.Password = options.Password;
            }
            if (!string.IsNullOrWhiteSpace(options.Name)) {
                user.Name = options.Name;
            }


            return true;
        }

        public Backer GetBackerById(int id)
        {
            if (id <= 0) {
                return null;
            }
            return BackersList.Where(s => s.Id == id)
                 .SingleOrDefault();
        }

        public ICollection<Project> SelectProject(int projectid)
        {
            var proj = Project.SearchProject(
                new SearchProjectOptions()
                {
                    Id = projectid
                }).SingleOrDefault();
            if(proj == null) {
                return null;
            }

            ProjectList.Add(proj);
            return ProjectList;
            
        }
    }
}
