using System;
using Autofac;
using Crowdfund_TeamProject.Core.Services;
using Crowdfund_TeamProject.Services;

namespace Crowdfund_TeamProject.Core
{
    public class ServiceRegistrator : Module
    {
        public static void RegisterServices(ContainerBuilder builder)
        {

            if (builder == null) {

                throw new ArgumentNullException(nameof(builder));
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

            builder
               .RegisterType<UpdatePostService>()
               .InstancePerLifetimeScope()
               .As<IUpdatePostService>();
           
            builder
                .RegisterType<Data.Crowdfund_TeamProjectDbContext>()
                .InstancePerLifetimeScope()
                .AsSelf();

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
