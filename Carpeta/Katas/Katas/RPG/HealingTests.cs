namespace Katas.RPG;

public class HealingTests
{
    const int initialHealth = 1000;
    const int healing = 1;
    
    [Test]
    public void HealAnotherCharacter() 
    {
        var sut = Character.Create(damage: healing, healing: healing);
        var victim = Character.Create();
        sut.Attack(victim);
        
        sut.Heal(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void HealthIsCappedAtInitialHealth()
    {
        var sut = Character.Create(healing: healing);
        var victim = Character.Create();
        
        sut.Heal(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void CannotHealDeadCharacter() {
        var sut = Character.Create(damage: initialHealth);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(sut.CanHeal(victim), Is.False);
    }

    [Test]
    public void CanHealDamagedCharacters() {
        var sut = Character.Create();
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(sut.CanHeal(victim), Is.True);
    }
}