namespace DomainEvents;
/*
    [x] con un suscriptor, se emite su evento, el suscriptor es notificado.
    [x] con un suscriptor, se emiten 2 eventos, el suscriptor es notificado 2 veces.
    [x] con un suscriptor, se emite otro evento, el suscriptor no es notificado.
    - sin suscriptor, se emite cualquier evento, no pasa nada.
    - varios suscriptores con el mismo evento, se emite un evento, ambos suscriptores son notificados.
    - varios suscriptores con distintos eventos, se emite un evento, sólo un suscriptor es notificado.
    - Suscriptor recibe typo de evento explícito para no tener que hacer casteo.
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
    
    [Test]
    public void NotifyWithNoSubscriberDoesNotThrow()
    {
        var eventBus = new DomainEventBus();

        Assert.DoesNotThrow(()=>eventBus.Emit(new TestEvent()));
    }
}

public struct TestEvent : DomainEvent
{
}

public class MockSubscriber : Subscriber
{
    public int TimesNotified { get; set; }

    public void Receive(DomainEvent domainEvent)
    {
        TimesNotified++;
    }
}