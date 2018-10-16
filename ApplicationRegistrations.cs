using CommonContracts;
using Microsoft.Extensions.DependencyInjection;
using PumpStation.Managers;
using RasberryPiHAL;

namespace PumpStation
{
    public static class ApplicationRegistrations
    {
        public static IServiceCollection AddApplicationRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IPumpManager, PumpManager>();
            services.AddScoped<IWaterLevelManager, WaterLevelManager>();
            //services.AddScoped<IHardwareAbstractionLayer , RasberryAbstractionLayer>();

            return services;
        }
    }
}

