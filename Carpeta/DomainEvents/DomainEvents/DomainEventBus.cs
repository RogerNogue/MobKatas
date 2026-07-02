namespace DomainEvents;

public class DomainEventBus
{
    private Subscriber subscriber;

    public void Subscribe<T>(Subscriber subscriber)
    {
        this.subscriber = subscriber;
    }

    public void Emit(DomainEvent domainEvent)
    {
        subscriber.Receive(domainEvent);
    }
}