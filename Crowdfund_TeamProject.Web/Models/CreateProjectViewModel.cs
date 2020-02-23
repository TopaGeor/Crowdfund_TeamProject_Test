using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund_TeamProject.Web.Models
{
    public class CreateProjectViewModel
    {
        public Core.Model.Options.AddProjectOptions Options { get; set; }

        public List<Object> Categories { get; set; }

        public CreateProjectViewModel()
        {
            Categories = new List<object>();
            foreach (var x in Enum.GetValues(typeof(Core.Model.ProjectCategory)))
            {
                Categories.Add(x);
            }
        }
    }
}
