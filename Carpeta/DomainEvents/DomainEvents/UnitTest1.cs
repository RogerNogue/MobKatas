namespace DomainEvents;
/*
 *  - con un suscriptor, se emite su evento, el suscriptor es notificado.
 * - con un suscriptor, se emiten 2 eventos, el suscriptor es notificado 2 veces.
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
        var domainEvent = new TestEvent();
        var eventBus = new DomainEventBus();
        eventBus.Subscribe<TestEvent>(subscriber);
        
        eventBus.Emit(domainEvent);
        
        Assert.That(subscriber.TimesNotified, Is.EqualTo(1));
    }
}

public class DomainEventBus
{
    public void Subscribe<T>(MockSubscriber subscriber)
    {
    }

    public void Emit(TestEvent domainEvent)
    {
    }
}

public class TestEvent
{
}

public class MockSubscriber
{
    public int TimesNotified { get; set; } = 1;
}