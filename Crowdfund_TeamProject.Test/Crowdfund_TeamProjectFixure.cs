using System;
using Autofac;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Data;

namespace Crowdfund_TeamProject.Test
{
    public class Crowdfund_TeamProjectFixure : IDisposable
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
            Container.Dispose();
        }
    }
}
