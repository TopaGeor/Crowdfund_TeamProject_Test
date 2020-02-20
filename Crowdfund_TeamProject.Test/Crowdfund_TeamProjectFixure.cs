using Autofac;
using Crowdfund_TeamProject.Data;

namespace Crowdfund_TeamProject.Test
{
    public class Crowdfund_TeamProjectFixure
    {
        public Crowdfund_TeamProjectDbContext DbContext { get; private set; }

        public ILifetimeScope Container { get; private set; }

        public Crowdfund_TeamProjectFixure()
        {
            Container = ServiceRegistrator.CreateContainer().BeginLifetimeScope();
            DbContext = Container.Resolve<Crowdfund_TeamProjectDbContext>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            Container.Dispose();
        }
    }
}
