using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Model.Options;

namespace Crowdfund.Core.Services
{
    public interface ITierService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Tier AddTierService(AddTierOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Tier UpdateTierService(UpdateTierOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tier GetTierById(int id);
    }
}
