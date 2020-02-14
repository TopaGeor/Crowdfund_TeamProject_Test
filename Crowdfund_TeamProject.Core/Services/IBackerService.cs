using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using System.Linq;

namespace Crowdfund.Core.Services
{
    public  interface IBackerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Backer AddBacker(AddBackerOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Backer UpdateBacker(UpdateBackerOptions options);

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
        Backer GetBackerById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backerId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        bool SelectProject(int backerId, int projectId);

    }
}
