using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.MusicStore.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Api.MusicStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            try
            {
                var host = BuildWebHost(configuration, args);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<AppDbContext>();

                    if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        context.Database.Migrate();
                    }

                    Seed.Initialize(services).Wait();
                }

                host.Run();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000;")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(configuration)
                 .UseSerilog((builderContext, config) =>
                 {
                     config
                         .MinimumLevel.Information()
                         .Enrich.FromLogContext()
                         .WriteTo.Console();
                 })
                 .Build();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
