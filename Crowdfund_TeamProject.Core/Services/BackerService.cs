using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Model;
using System.Linq;

namespace Crowdfund.Core.Services
{
    public class BackerService : IBackerService
    {
        readonly private Crowdfund_TeamProjectDbContext context_;
        readonly private IProjectService Project;

        public BackerService(Crowdfund_TeamProjectDbContext context)
        {
            context_ = context;
            Project = new ProjectService(
                new CreatorService(new Crowdfund_TeamProjectDbContext()),
                new BackerService(new Crowdfund_TeamProjectDbContext()),
                new Crowdfund_TeamProjectDbContext());
        }

        public Backer AddBacker(AddBackerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Name) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.Password))
            {
                return null;
            }

            var exist = SearchBacker(
                new SearchBackerOptions()
                {
                    Name = options.Name,
                    Email = options.Email
                }).Any();

            if (exist)
            {
                return null;
            }

            var newBacker = new Backer()
            {
                Email = options.Email,
                Name = options.Name,
                Password = options.Password
            };
            context_.Add(newBacker);

            try
            {
                context_.SaveChanges();
            }
            catch
            {
                return null;
            }

            return newBacker;
        }

        public IQueryable<Backer> SearchBacker(SearchBackerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_.
                Set<Backer>().
                AsQueryable();

            if (options.Id > 0)
            {
                query = query.
                    Where(b => b.Id == options.Id);
            }

            if (string.IsNullOrWhiteSpace(options.Name))
            {
                query = query.
                    Where(b => b.Name == options.Name);
            }

            if (string.IsNullOrWhiteSpace(options.Email))
            {
                query = query.Where(b => b.Email == options.Email);
            }

            return query.Take(500);
        }

        public Backer UpdateBacker(UpdateBackerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (options.Id <= 0)
            {
                return null;
            }

            var user = GetBackerById(options.Id);

            if (user == null)
            {
                return null;
            }

            //The name needs to be unique
            var exist = SearchBacker(
                new SearchBackerOptions()
                {
                    Name = options.Name
                }).Any();

            if (exist)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Password))
            {
                user.Password = options.Password;
            }

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                user.Name = options.Name;
            }

            context_.Update(user);
            try
            {
                context_.SaveChanges();
            }
            catch
            {
                return null;
            }

            return user;
        }

        public Backer GetBackerById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return context_.
                Set<Backer>().
                SingleOrDefault(s => s.Id == id);
        }

        public bool SelectProject(int backerId, int projectId)
        {
            var proj = Project.SearchProject(
                new SearchProjectOptions()
                {
                    Id = projectId
                }).SingleOrDefault();

            if (proj == null)
            {
                return false;
            }

            var backer = GetBackerById(backerId);

            if (backer == null)
            {
                return false;
            }

            var pb = new ProjectBacker()
            {
                BackerId = backer.Id,
                ProjectId = proj.Id,
                Backer = backer,
                Project = proj
            };

            backer.FundedProject.Add(pb);
            proj.Backers.Add(pb);

            context_.Update(backer);
            context_.Update(proj);
            try
            {
                context_.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
