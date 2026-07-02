namespace DomainEvents;
/*
    [x] con un suscriptor, se emite su evento, el suscriptor es notificado.
    [x] con un suscriptor, se emiten 2 eventos, el suscriptor es notificado 2 veces.
    - con un suscriptor, se emite otro evento, el suscriptor no es notificado.
    - sin suscriptor, se emite cualquier evento, no pasa nada.
    - varios suscriptores con el mismo evento, se emite un evento, ambos suscriptores son notificados.
    - varios suscriptores con distintos eventos, se emite un evento, sólo un suscriptor es notificado.
 */

public class Tests
{
    [Test]
    public void NotifyOneSubscriber()
    {
        var subscriber = new MockSubscriber();
        var eventBus = new DomainEventBus();
        eventBus.Subscribe<TestEvent>(subscriber);
        
        eventBus.Emit(new TestEvent());
        
        Assert.That(subscriber.TimesNotified, Is.EqualTo(1));
    }
    
    [Test]
    public void NotifyOneSubscriber_Twice()
    {
        var subscriber = new MockSubscriber();
        var eventBus = new DomainEventBus();
        eventBus.Subscribe<TestEvent>(subscriber);
        
        eventBus.Emit(new TestEvent());
        eventBus.Emit(new TestEvent());
        
        Assert.That(subscriber.TimesNotified, Is.EqualTo(2));
    }
}

public class DomainEventBus
{
    private Subscriber subscriber;

    public void Subscribe<T>(Subscriber subscriber)
    {
        this.subscriber = subscriber;
    }

    public void Emit(TestEvent domainEvent)
    {
        subscriber.Receive(domainEvent);
    }
}

public struct TestEvent
{
}

public interface Subscriber
{
    void Receive(TestEvent domainEvent);
}

public class MockSubscriber : Subscriber
{
    public int TimesNotified { get; set; }

    public void Receive(TestEvent domainEvent)
    {
        TimesNotified++;
    }
}