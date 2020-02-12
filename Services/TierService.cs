using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Model.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Services
{
    public class TierService : ITierService
    {
        ICollection<Tier> TierList = new List<Tier>();

        public Tier AddTierService(AddTierOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (options.Project == null)
            {
                return null;
            }

            if (options.Project.Id < 1)
            {
                return null;
            }

            if (options.Ammount < 1)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Description))
            {
                return null;
            }

            Tier tier = new Tier()
            {
                Amount = options.Ammount,
                Project = options.Project,
                Description = options.Description
            };

            TierList.Add(tier);
            return tier;
        }

        
    }
}
