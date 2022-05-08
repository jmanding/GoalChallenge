using Autofac;
using GoalChallenge.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace GoalChallenge.Api.Modules
{
    /// <summary>
    /// Autofac module
    /// </summary>
    public class AutofacModule : Autofac.Module
    {
        /// <summary>
        /// Load Autofac Module
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new System.Reflection.Assembly[]
            {
                //Application
                typeof(GoalChallenge.Application.Commands.Items.RemoveItemFromInventoryByNameCommand).Assembly,

                // Infrastructure
                typeof(Infrastructure.Data.Repositories.Items.IInventoryRepository).Assembly,

                // Domain
                typeof(Domain.Events.Base.BaseDomainEvent).Assembly,
              
               // Api.Query
                typeof(Api.Query.Queries.Items.IItemQuery).Assembly,

               System.Reflection.Assembly.GetExecutingAssembly()
            };

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().InstancePerDependency();

            builder.Register<Serilog.ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .WriteTo.Console().
                    CreateLogger();
            }).InstancePerLifetimeScope();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<EFContext>().UseInMemoryDatabase(databaseName: "Test").UseLazyLoadingProxies();

            builder.RegisterType<EFContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope();
        }
    }
}
