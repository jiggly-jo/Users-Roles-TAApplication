using Microsoft.AspNetCore.Hosting;
using MVC_for_TA_Applications.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using MVC_for_TA_Applications.Areas.Identity.Data;

namespace MVC_for_TA_Applications
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var um = services.GetRequiredService<UserManager<TAUser>>();
                    var rm = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var context = services.GetRequiredService<TAUsersRolesDB>();
                    await SeedUsersRolesDB.InitializeAsync(context, um, rm);
                    var context2 = services.GetRequiredService<ApplicationContext>();
                    await DbInitializer.InitializeAsync(context2, um);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }


            host.Run();
        }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
