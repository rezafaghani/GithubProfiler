using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Profiler.Infrastructure;

namespace Profiler.Api.Infrastructure.Factories
{
    public class ProfileContextContextFactory : IDesignTimeDbContextFactory<ProfileContext>
    {
        public ProfileContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProfileContext>();

            optionsBuilder.UseNpgsql(config["ConnectionString"],  o => o.MigrationsAssembly("Profiler.Api"));

            return new ProfileContext(optionsBuilder.Options);
        }
    }
}