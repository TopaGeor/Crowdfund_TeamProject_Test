using System;
using System.Collections.Generic;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
    interface IProjectService
    {
        bool CreateProject(AddProjectOptions options);

        bool UpdateProject(int id, UpdateProjectOptions options);

        ICollection<Project> SearchProject(SearchProjectOptions options);

    }
}
