using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund.Core.Services
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
   }
}
