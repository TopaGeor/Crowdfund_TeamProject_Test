using System;
using System.Collections.Generic;
using Crowdfund_TeamProject.Core.Model;

namespace Crowdfund_TeamProject.Web.Models
{
    public class CreatorProjectViewModel
    {
        public Creator Creator { get; set; }

        public ICollection<Project> ProjectList { get; set; }

      
    }
}
