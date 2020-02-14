using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Model.Options;

namespace Crowdfund.Core.Services
{
    public interface ITierService
    {
        Tier AddTierService(AddTierOptions options);

        Tier UpdateTierService(UpdateTierOptions options);

        Tier GetTierById(int id);
    }
}
