using Crowdfund_TeamProject.Core.Model;
using System.Collections.Generic;

namespace Crowdfund_TeamProject.Web.Models
{
    public class CreatorProjectViewModel
    {
        public Creator Creator { get; set; }

        public ICollection<Project> ProjectList { get; set; }
    }
}
