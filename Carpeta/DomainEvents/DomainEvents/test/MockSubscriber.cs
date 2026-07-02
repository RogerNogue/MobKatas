namespace DomainEvents;

public class MockSubscriber : Subscriber
{
    public int TimesNotified { get; set; }

    public void Receive(DomainEvent domainEvent)
    {
        TimesNotified++;
    }
}