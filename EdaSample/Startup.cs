using EdaSample.EventBus.Simple;
using EdaSample.EventHandlers;
using EdaSample.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdaSample
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEventHandler, CustomerCreatedEventHandler>();
            services.AddSingleton<IEventBus, PassThroughEventBus>();

        }

        public void Configure(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<CustomerCreatedEvent, CustomerCreatedEventHandler>();

        }
    }
}
