using ePizzaHut.Services.Implementations;
using ePizzaHut.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ePizzaHut.WebUI.Configuration
{
    public static class ConfigurationDepenencies
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IAuthentationService, AuthentationService>();
        }
    }
}
