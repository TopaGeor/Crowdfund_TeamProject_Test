using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Model.Options;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund.Core.Services
{
    public class TierService : ITierService
    {
        private readonly Crowdfund_TeamProjectDbContext context_;

        public TierService(Crowdfund_TeamProjectDbContext context)
        {
            context_ = context;
        }

        public async Task<ApiResult<Tier>> AddTierServiceAsync(AddTierOptions options)
        {
            if (options == null)
            {
                return new ApiResult<Tier>
                     (StatusCode.BadRequest, $"null {options}");
            }

            if (options.Project == null)
            {
                return new ApiResult<Tier>
                    (StatusCode.BadRequest, $"not valid {options.Project}");
            }

            if (options.Project.Id < 1)
            {
                return new ApiResult<Tier>
                    (StatusCode.BadRequest, $"not valid {options.Project.Id}");
            }

            if (options.Ammount < 1)
            {
                return new ApiResult<Tier>
                     (StatusCode.BadRequest, $"not valid {options.Ammount}");
            }

            if (string.IsNullOrWhiteSpace(options.Description))
            {
                return new ApiResult<Tier>
                    (StatusCode.BadRequest, $"not valid {options.Description}");
            }

            Tier tier = new Tier()
            {
                Amount = options.Ammount,
                Project = options.Project,
                Description = options.Description
            };

           await context_.AddAsync(tier);
            try
            {
              await  context_.SaveChangesAsync();
            }
            catch
            {
                return new ApiResult<Tier>
                     (StatusCode.InternalServerError,
                       "Error Save Tier");
            }

            return ApiResult<Tier>
                    .CreateSuccess(tier);
        }

        public async Task<ApiResult<Tier>> UpdateTierServiceAsync(int id, UpdateTierOptions options)
        {
            if (options == null) {
                return new ApiResult<Tier>
                   (StatusCode.BadRequest, $"null {options}");
            }

            if (id < 1)
            {
                return new ApiResult<Tier>
                   (StatusCode.BadRequest, $"not valid  {id}");
            }

            var tier =  await GetTierByIdAsync(id);

            if (tier == null)
            {
                return new ApiResult<Tier>
                   (StatusCode.NotFound, $"not found {tier}");
            }

            if(options.Ammount > 0)
            {
                tier.Data.Amount = options.Ammount;
            }

            if(!string.IsNullOrWhiteSpace(options.Description))
            {
                tier.Data.Description = options.Description;
            }

           return ApiResult<Tier>.CreateSuccess(tier.Data);
        }

        public async Task<ApiResult<Tier>> GetTierByIdAsync(int id)
        {
            if (id < 1)
            {
                return new ApiResult<Tier>(
                   StatusCode.BadRequest, $"not valid {id}");

            }

            var result = await context_
                        .Set<Tier>()
                        .Where(t => t.Id == id)
                        .SingleOrDefaultAsync();

            if (result == null) {
                return new ApiResult<Tier>(
                     StatusCode.NotFound, $"this {result} dont exist");
            }

            return ApiResult<Tier>.CreateSuccess(result);
        }
    }
}
