using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polly;

namespace Profiler.Api.Infrastructure.Extension
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}",
                        typeof(TContext).Name);

                    var retryInSeconds = 5;
                    var retry = Policy.Handle<NpgsqlException>()
                        .WaitAndRetryForever(
                            (_, _) => TimeSpan.FromSeconds(retryInSeconds),
                            (exception, retryAttempt, _, _) =>
                            {
                                logger.LogWarning(exception,
                                    "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry}",
                                    typeof(TContext).Name, exception.GetType().Name, exception.Message, retryAttempt);
                            });
                    retry.Execute(() => InvokeSeeder(seeder, context, services));



                    logger.LogInformation("Migrated database associated with context {DbContextName}",
                        typeof(TContext).Name);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex,
                        "An error occurred while migrating the database used on context {DbContextName}",
                        typeof(TContext).Name);
                }
            }

            return webHost;
        }
        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }

    }
}