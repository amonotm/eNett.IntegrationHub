using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.SharedInterfaces;
using eNett.IntegrationHub.BusinessObjects;
using RabbitBus;
using RabbitBus.Serialization.Json;

namespace eNett.IntegrationHub.Messaging
{
    public class MessageBroker : IMessageBroker
    {
        public void PostChange(Change change)
        {
            var rabbit = "amqp://guest:guest@enttst02:5672/%2f";
            var exchange = "IntegrationHub";
            var routingKey = change.SystemName;

            var bus = new BusBuilder()
                .Configure(
                    ctx =>
                    {
                        ctx.WithDefaultSerializationStrategy(new JsonSerializationStrategy());
                        ctx.Publish<Change>().WithExchange(exchange);
                    }
                )
                .Build();

            bus.Connect(rabbit);

            bus.Publish(change, routingKey);
            
            bus.Close();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Action<Change> action, string sourceSystem)
        {
            throw new NotImplementedException();
        }
    }
}
