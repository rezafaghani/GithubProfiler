using Autofac;
using Profiler.Api.Application.Queries.GithubProfileQueries;
using Profiler.Domain.AggregatesModel;
using Profiler.Domain.SeedWork;
using Profiler.Infrastructure.Idempotency;
using Profiler.Infrastructure.Repositories;

namespace Profiler.Api.Infrastructure.AutofacModules
{

    public class ApplicationModule
        : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }
     protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new GithubProfileQuery(QueriesConnectionString))
                .As<IGithubProfileQuery>()
                .InstancePerLifetimeScope();
           
            builder.RegisterType<ProfileRepoRepository>()
                .As<IProfileRepoRepository>()
                .InstancePerLifetimeScope();
            
            
            builder.RegisterType<ProfileRepository>()
                .As<IProfileRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

        }
    }
}
