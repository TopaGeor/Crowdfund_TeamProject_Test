using Crowdfund_TeamProject.Core.Model.Options;

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

        public CreateTierViewModel()
        {
        }
    }
}
