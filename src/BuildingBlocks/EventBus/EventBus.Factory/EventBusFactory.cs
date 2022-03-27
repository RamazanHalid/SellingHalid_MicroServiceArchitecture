

using EventBus.AzureServiceBus;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.RabbitMQ;
using System;

namespace EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.EventBusype switch
            {
                EventBusype.AzureServiceBus => new EventServiceBus(config, serviceProvider),
                _ => new EventBusRabbitMQ(config, serviceProvider),
            };
        }
    }
}
