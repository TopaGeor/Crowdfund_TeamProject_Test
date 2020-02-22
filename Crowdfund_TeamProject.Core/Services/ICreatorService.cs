using System.Linq;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;

namespace Crowdfund_TeamProject.Services
{
    public interface ICreatorService
   {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
       Task<ApiResult<Creator>> AddCreatorAsync(AddCreatorOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResult<Creator>> UpdateCreatorAsync(int id, UpdateCreatorOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Creator> SearchCreator(SearchCreatorOptions options);

        Task<ApiResult<Creator>> GetCreatorByIdAsync(int id);
   }
}
