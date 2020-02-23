using System;
using System.Collections.Generic;
using Crowdfund_TeamProject.Core.Model;

namespace Crowdfund_TeamProject.Web.Models
{
    public class BackerProjectViewModel
    {
        public Backer Backer { get; set; }

        public ICollection<Project> ProjectList { get; set; }

      
    }
}
