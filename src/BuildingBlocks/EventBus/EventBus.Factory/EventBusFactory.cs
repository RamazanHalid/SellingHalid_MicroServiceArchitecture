using EventBus.AzureServiceBus;
using EventBus.RabbitMQ;
using EventBust.Base;
using EventBust.Base.Abstraction;
using System;

namespace EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.EventBusType switch
            {
                EventBusType.AzureServiceBus => new EventServiceBus(config, serviceProvider),
                _ => new EventBusRabbitMQ(config, serviceProvider),
            };
        }
    }
}
