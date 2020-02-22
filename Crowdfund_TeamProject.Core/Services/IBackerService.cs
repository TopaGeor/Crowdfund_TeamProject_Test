using System.Linq;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;

namespace Crowdfund_TeamProject.Services
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
