using PersonManagement.Domain;
using PersonManagement.Domain.Data;

namespace PersonManagement.MessageBus.Vendor
{
    public class MessageBusEventPublisher : IEventPublisher
    {
        public Task PublishPersonStateChangedEvent(PersonUpdatedEvent @event)
        {
            // TODO: here we will have the integration with the message bus, e.g. RabbitMQ, Azure Service Bus, Kafka etc.
            // we will map @event to the message bus specific event data and publish it
            throw new NotImplementedException();
        }
    }
}
