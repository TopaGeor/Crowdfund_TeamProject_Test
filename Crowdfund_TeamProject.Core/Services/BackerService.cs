using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund.Core.Services
{
    public class BackerService : IBackerService
    {
         private readonly Crowdfund_TeamProjectDbContext context_;
         private readonly IProjectService project_;
         private readonly ILoggerService logger_;


        public BackerService(
            Crowdfund_TeamProjectDbContext context,
            IProjectService prsv,
            ILoggerService logger)
        {
            context_ = context;
            project_ = prsv;
            logger_ = logger;
        }

        public  async Task<ApiResult<Backer>> AddBackerAsync(AddBackerOptions options)
        {
            if (options == null)
            {
                return new ApiResult<Backer>
                    (StatusCode.BadRequest, $"null {options}");
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return new ApiResult<Backer>
                   (StatusCode.BadRequest, $"null {options.Name}");
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return new ApiResult<Backer>
                   (StatusCode.BadRequest, $"null {options.Email} ");
            }

            var exist = await SearchBacker(
                new SearchBackerOptions()
                {
                    Name = options.Name,
                    Email = options.Email
                }).AnyAsync();

            if (exist) {
               return new ApiResult<Backer>
                  (StatusCode.Conflict, "this backer account already exist");
            }

            var newBacker = new Backer()
            {
                Email = options.Email,
                Name = options.Name,
            };

            await context_.AddAsync(newBacker);

            try
            {
               await context_.SaveChangesAsync();
            }
            catch
            {
                logger_.LogError(StatusCode.InternalServerError,
                    $"Error Save account with Name {newBacker.Name}");
                
                return new ApiResult<Backer>
                     (StatusCode.InternalServerError,
                       "Error Save Backer account");
            }

            return ApiResult<Backer>
                    .CreateSuccess(newBacker);
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

        public async Task<ApiResult<Backer>> UpdateBackerAsync(int id, UpdateBackerOptions options)
        {
            if (options == null){

                return new ApiResult<Backer>(
                    StatusCode.BadRequest, $"null {options}");
            }

            if (id <= 0)
            {
                return new ApiResult<Backer>(
                    StatusCode.BadRequest, $"not valid creator {id}");
            }

            var user = await GetBackerByIdAsync(id);

            if (user == null)
            {
                return new ApiResult<Backer>(
                    StatusCode.NotFound, $" {user} dont exist");
            }

            //The name needs to be unique
            var exist = await SearchBacker(
                new SearchBackerOptions()
                {
                    Name = options.Name
                }).AnyAsync();

            if (exist)
            {
                return new ApiResult<Backer>
                    (StatusCode.Conflict, $"this {options.Name} already exist");
            }

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                user.Data.Name = options.Name;
            }

            return ApiResult<Backer>
                     .CreateSuccess(user.Data);
        }

        public async Task<ApiResult<Backer>> GetBackerByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new ApiResult<Backer>(
                   StatusCode.BadRequest, $"not valid {id}");
            }

            var result = await context_
                .Set<Backer>()
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            if (result == null) {
                return new ApiResult<Backer>(
                     StatusCode.NotFound, $"this {result} dont exist");
            }

            return ApiResult<Backer>.CreateSuccess(result);
        }

        public async Task<ApiResult<Backer>> SelectProjectAsync(int backerId, int projectId)
        {
            var proj = await project_.SearchProjectByIdAaync(projectId);

            if (proj == null)
            {
                return new ApiResult<Backer>(
                   StatusCode.BadRequest, $"not valid {proj}");
            }

            var backer = await GetBackerByIdAsync(backerId);

            if (backer == null)
            {
                return new ApiResult<Backer>
                   (StatusCode.NotFound, $"not found {backer}");
            }

            backer.Data.FundedProject.Add(proj.Data);

            return ApiResult<Backer>.CreateSuccess(backer.Data);
        }
    }
}
