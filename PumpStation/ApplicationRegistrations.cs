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
            services.AddTransient<IPumpManager, PumpManager>();
            services.AddTransient<IWaterLevelManager, WaterLevelManager>();
            services.AddSingleton<IHardwareAbstractionLayer, RasberryAbstractionLayer>();

            return services;
        }
    }
}

