using System.Linq;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;

namespace Crowdfund_TeamProject.Services
{
    public  interface IProjectService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResult<Project>> CreateProjectAsync(int creatorId,AddProjectOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ApiResult<Project>> UpdateProjectAsync(int Projectid, UpdateProjectOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Project> SearchProject(int id, SearchProjectOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<Project>> SearchProjectByIdAaync(int id);
    }
}
