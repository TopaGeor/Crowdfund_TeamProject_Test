using System.Threading.Tasks;
using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Model.Options;

namespace Crowdfund.Core.Services
{
    public interface ITierService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
       Task<ApiResult<Tier>> AddTierServiceAsync(AddTierOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResult<Tier>> UpdateTierServiceAsync(int id, UpdateTierOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<Tier>> GetTierByIdAsync(int id);
    }
}
