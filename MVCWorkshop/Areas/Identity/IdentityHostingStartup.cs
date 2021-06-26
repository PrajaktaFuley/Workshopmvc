using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCWorkshop.Data;
using MVCWorkshop.Models;

[assembly: HostingStartup(typeof(MVCWorkshop.Areas.Identity.IdentityHostingStartup))]
namespace MVCWorkshop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("DefaultConnection")));
                services.AddIdentity<SunSign, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            });
        }
    }
}