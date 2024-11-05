using PersonManagement.Domain.Data;

namespace PersonManagement.Domain;

public interface IEventPublisher
{
    Task PublishPersonStateChangedEvent(PersonUpdatedEvent @event);
}