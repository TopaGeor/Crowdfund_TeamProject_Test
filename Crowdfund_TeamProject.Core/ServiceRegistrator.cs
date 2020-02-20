using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Crowdfund.Core.Services;

namespace Crowdfund_TeamProject
{
    public class ServiceRegistrator : Module
    {
        public static IContainer RegisterServices(ContainerBuilder builder)
        {

            if(builder == null) {
                throw new ArgumentNullException();
            }

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

            builder
                .RegisterType<LoggerService>()
                .InstancePerLifetimeScope()
                .As<ILoggerService>();

            return builder.Build();

        }

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            RegisterServices(builder);
            return builder.Build();
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterServices(builder);
        }
    }
}
