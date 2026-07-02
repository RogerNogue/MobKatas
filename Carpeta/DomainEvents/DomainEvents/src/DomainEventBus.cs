namespace DomainEvents;

public class DomainEventBus
{
    private List<Subscriber> subscriber = [];

    public void Subscribe<T>(Subscriber subscriber)
    {
        this.subscriber.Add(subscriber);
    }

    public void Emit(DomainEvent domainEvent)
    {
        foreach (var subscriber in this.subscriber)
            subscriber.Receive(domainEvent);
    }
}