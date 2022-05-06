using Autofac;
using GoalChallenge.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoalChallenge.Infrastructure
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new System.Reflection.Assembly[]
            {
              

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
