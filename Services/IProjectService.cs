using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using System.Collections.Generic;

namespace Crowdfund.Core.Services
{
    interface IProjectService
    {
        bool CreateProject(AddProjectOptions options);

        bool UpdateProject(int id, UpdateProjectOptions options);

        ICollection<Project> SearchProject(SearchProjectOptions options);
    }
}
