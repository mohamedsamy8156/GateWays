using Gateways.API;
using Gateways.Domain.DataModels;
using Gateways.Domain.Shared.Interfaces;
using Gateways.Infrastructure.Persistence;
using Gateways.Service.Queries;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateways.UnitTests
{
    public class TestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        //protected override IHostBuilder CreateHostBuilder()
        //{
        //    var builder = Host.CreateDefaultBuilder()
               
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder
        //                .ConfigureTestServices((services) =>
        //                {
        //                    services
        //                        .AddControllers()
        //                        .AddApplicationPart(typeof(Startup).Assembly);
        //                });
        //        });

        //    return builder;
        //}

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //builder.UseStartup<Startup>();
            //base.ConfigureWebHost(builder);

            try
            {
                builder.ConfigureServices(services =>
                {

                    var context = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<GatewayDbContext>));
                    if (context != null)
                    {
                        bool isDeleted = services.Remove(context);
                    }

                    services.AddDbContext<GatewayDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("GatewaysInMemoryDb");//.UseInternalServiceProvider();
                    });

                    // Build the service provider.
                    var serviceProvider = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database contexts
                    using var scope = serviceProvider.CreateScope();
                    var scopedServices = scope.ServiceProvider;

                    var context1 = serviceProvider.GetRequiredService<GatewayDbContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<TestApplicationFactory<TStartup>>>();

                    services.TryAddTransient(typeof(IQueryHandler<GetAllGatewaysQuery, List<GatewayModel>>), typeof(GetAllGatewaysQueryHandler));



                    // Ensure the database is created.

                    try
                    {
                        // Seed the database with some specific test data.
                        GatewaysData.SeedingDataAsync(context1);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
