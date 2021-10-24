using ePizzaHut.Entity;
using ePizzHut.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ePizzaHut.Services.Configuration
{
    public static class ConfigurationRepositories
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) 
                => { options.UseSqlServer(configuration.GetConnectionString("con")); });
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddScoped<DbContext, AppDbContext>();
        }
    }
}
