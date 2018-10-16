using EdaSample.EventBus.Simple;
using EdaSample.EventHandlers;
using EdaSample.Events;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EdaSample
{
    class Program
    {
        static void Main(string[] args)
        {



            var serviceProvider = new ServiceCollection()
                .AddTransient<IEventHandler, CustomerCreatedEventHandler>()
                .AddTransient<IEventBus, PassThroughEventBus>()
               .BuildServiceProvider();
            var eventBus = serviceProvider.GetRequiredService<IEventBus>();
            eventBus.Subscribe<CustomerCreatedEvent, CustomerCreatedEventHandler>();


            eventBus.PublishAsync(new CustomerCreatedEvent("张飞", "zhangfei@163.com"));

            BuildWebHost(args).Run();
            Console.ReadKey();

        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
