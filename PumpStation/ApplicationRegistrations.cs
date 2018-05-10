using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PumpStation.BackgroundWorkers;
using PumpStation.Managers;
using PumpStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation
{
    public static class ApplicationRegistrations
    {
        public static IServiceCollection AddApplicationRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IPumpManager, PumpManager>();
            services.AddTransient<IWaterLevelManager, WaterLevelManager>();
            services.AddTransient<IGPIORepository, GPIORepository>();
            services.AddSingleton<IHostedService, TimedBW>();

            return services;
        }
    }
}
