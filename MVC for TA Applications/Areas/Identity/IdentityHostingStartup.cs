using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_for_TA_Applications.Areas.Identity.Data;
using MVC_for_TA_Applications.Data;

[assembly: HostingStartup(typeof(MVC_for_TA_Applications.Areas.Identity.IdentityHostingStartup))]
namespace MVC_for_TA_Applications.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TAUsersRolesDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TAUsersRolesDBConnection")));

                services.AddDefaultIdentity<TAUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TAUsersRolesDB>();

            });
        }
    }
}