using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
    interface IProjectService
    {
        Project CreateProject(int creatorId,AddProjectOptions options);

        bool UpdateProject(int Projectid, UpdateProjectOptions options);

        IQueryable<Project> SearchProject(SearchProjectOptions options);

    }
}
