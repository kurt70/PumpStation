using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Console;
using Hangfire.Heartbeat;
using Hangfire.Heartbeat.Server;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PumpStation.Managers;
using PumpStation.Misc;
using Swashbuckle.AspNetCore.Swagger;

namespace PumpStation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddHangfire(config=> 
            {
                config.UseStorage(new MemoryStorage());
                config.UseConsole(new ConsoleOptions());
                config.UseHeartbeatPage(new TimeSpan(0, 0, 5));
            });
            
            services.AddApplicationRegistrations();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpStatusCodeExceptionMiddleware();
            }
            else
            {
                app.UseHttpStatusCodeExceptionMiddleware();
            }
            app.UseMvc();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });            

            app.UseSwagger();
            app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "API V1");
                c.SwaggerEndpoint("/pumpstation/swagger/v1/swagger.json", "Deployed API V1");
            });
            app.UseHangfireServer(new BackgroundJobServerOptions
            {   
                HeartbeatInterval = new System.TimeSpan(0, 1, 0),
                ServerCheckInterval = new System.TimeSpan(0, 1, 0),
                SchedulePollingInterval = new System.TimeSpan(0, 1, 0)
            });
            app.UseHangfireDashboard();
            app.UseHangfireServer(additionalProcesses: new[] { new SystemMonitor(new TimeSpan(0, 0, 5)) });
        }
    }
}
