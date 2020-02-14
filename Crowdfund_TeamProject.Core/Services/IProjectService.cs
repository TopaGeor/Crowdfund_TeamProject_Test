using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using System.Linq;

namespace Crowdfund.Core.Services
{
    interface IProjectService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatorId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Project CreateProject(int creatorId,AddProjectOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Projectid"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Project UpdateProject(int Projectid, UpdateProjectOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Project> SearchProject(SearchProjectOptions options);
    }
}
