namespace DomainEvents;

public interface Subscriber
{
    void Receive(DomainEvent domainEvent);
}