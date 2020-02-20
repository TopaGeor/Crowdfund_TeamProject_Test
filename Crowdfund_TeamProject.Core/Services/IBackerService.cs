using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund.Core.Services
{
    public  interface IBackerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
         Task<ApiResult<Backer>> AddBackerAsync(AddBackerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResult<Backer>> UpdateBackerAsync(int id, UpdateBackerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Backer> SearchBacker(SearchBackerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<Backer>> GetBackerByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backerId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<ApiResult<Backer>> SelectProjectAsync(int backerId, int projectId);

    }
}
