using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Model.Options;

namespace Crowdfund_TeamProject.Services
{
    public class TierService : ITierService
    {
        private readonly Crowdfund_TeamProjectDbContext context_;

        public TierService(Crowdfund_TeamProjectDbContext context)
        {
            context_ = context;
        }

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

            context_.Add(tier);
            try
            {
                context_.SaveChanges();
            }
            catch
            {
                return null;
            }

            return tier;
        }

        public Tier UpdateTierService(UpdateTierOptions options)
        {
            if (options.Id < 1)
            {
                return null;
            }

            Tier tier = GetTierById(options.Id);

            if (tier == null)
            {
                return null;
            }

            if(options.Ammount > 0)
            {
                tier.Amount = options.Ammount;
            }

            if(!string.IsNullOrWhiteSpace(options.Description))
            {
                tier.Description = options.Description;
            }

            context_.Update(tier);
            try
            {
                context_.SaveChanges();
            }
            catch
            {
                return null;
            }

            return tier;
        }

        public Tier GetTierById(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return context_.
                Set<Tier>().
                Find(id);
        }
    }
}
