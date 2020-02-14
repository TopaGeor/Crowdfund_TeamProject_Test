using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using System.Linq;

namespace Crowdfund.Core.Services
{
    public interface ICreatorService
   {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Creator AddCreator(AddCreatorOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Creator UpdateCreator(int id, UpdateCreatorOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Creator> SearchCreator(SearchCreatorOptions options);
   }
}
