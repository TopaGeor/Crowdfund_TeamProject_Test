using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Model.Options;

namespace Crowdfund_TeamProject.Services
{
    public interface ITierService
    {
        Tier AddTierService(AddTierOptions options);

        Tier UpdateTierService(UpdateTierOptions options);

        Tier GetTierById(int id);
    }
}
