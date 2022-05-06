using Autofac;
using GoalChallenge.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoalChallenge.Api.Modules
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new System.Reflection.Assembly[]
            {
                //Application
                typeof(GoalChallenge.Application.Commands.Items.AddItemCommand).Assembly,
                // Infrastructure
                typeof(Infrastructure.Data.Repositories.Items.IItemRepository).Assembly,
              
               // Api.Query
               typeof(Api.Query.Queries.Items.IItemQuery).Assembly,
               // ServiceBus
               //typeof(RethinkSoftware.ServiceBus.Sender.Bus.ISenderBus).Assembly,

               System.Reflection.Assembly.GetExecutingAssembly()
            };

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().InstancePerDependency();

            //builder.Register(c => new SqlConnection(connectionString)).As<IDbConnection>().InstancePerLifetimeScope();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<EFContext>().UseInMemoryDatabase(databaseName: "Test");

            builder.RegisterType<EFContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope();
        }
    }
}
