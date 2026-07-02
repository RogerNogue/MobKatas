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
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}