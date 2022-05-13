using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderService.Api.Extensions;
using OrderService.Infrastructure.Context;
using OrderService.Persistence.Context;
using System;

namespace OrderService.Api
{
    public class Program
    {
        private static string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        private static IConfiguration configuration
        {
            get
            {
                return new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                     .AddEnvironmentVariables()
                    .Build();
            }
        }

      

        public static IWebHost BuildWebHost(IConfiguration configuration, string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateOnBuild = false;
                    options.ValidateScopes = false;
                })
                .ConfigureAppConfiguration(i => i.AddConfiguration(configuration))
                .UseStartup<Startup>()
                  .Build();
        }

        public static void Main(string[] args)
        {
            var host = BuildWebHost(configuration, args);
 
            host.MigrateDbContext<OrderDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<OrderDbContext>>();

                var dbContextSeeder = new OrderDbContextSeed();
                dbContextSeeder.SeedAsync(context, logger)
                    .Wait();
            });


            host.Run();
        }
    }
}
    