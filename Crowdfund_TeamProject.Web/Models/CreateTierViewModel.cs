using Crowdfund_TeamProject.Core.Model.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund_TeamProject.Web.Models
{
    public class CreateTierViewModel
    {
        public AddTierOptions Options { get; set; }
        public int ProjectId { get; set; }

        public CreateTierViewModel(int id)
        {
            ProjectId = id;
        }
    }
}
