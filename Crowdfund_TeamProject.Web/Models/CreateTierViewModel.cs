using Crowdfund_TeamProject.Core.Model.Options;

namespace Crowdfund_TeamProject.Web.Models
{
    public class CreateTierViewModel
    {
        public AddTierOptions Options { get; set; }
       
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public CreateTierViewModel(int id, string title)
        {
            ProjectId = id;
            ProjectTitle = title;
        }

        public CreateTierViewModel()
        {
        }
    }
}
