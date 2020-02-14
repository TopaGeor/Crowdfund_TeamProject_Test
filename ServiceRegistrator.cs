using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Crowdfund.Core.Services;

namespace Crowdfund_TeamProject
{
    class ServiceRegistrator
    {
        public static IContainer GetContainer()
        {

            var builder = new ContainerBuilder();

            builder
                .RegisterType<ProjectService>()
                .InstancePerLifetimeScope()
                .As<IProjectService>();

            builder
                .RegisterType<CreatorService>()
                .InstancePerLifetimeScope()
                .As<ICreatorService>();

            builder
                .RegisterType<BackerService>()
                .InstancePerLifetimeScope()
                .As<IBackerService>();

            builder
                .RegisterType<TierService>()
                .InstancePerLifetimeScope()
                .As<ITierService>();

            return builder.Build();

        }
    }
}
