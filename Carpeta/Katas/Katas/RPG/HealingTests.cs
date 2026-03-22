namespace Katas.RPG;

public class HealingTests
{
    const int initialHealth = 1000;
    const int healing = 1;
    
    [Test]
    public void HealAnotherCharacter() 
    {
        var attacker = Character.Create(damage: healing);
        var sut = Character.Create(healing: healing);
        attacker.Attack(sut);
        
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void HealthIsCappedAtInitialHealth()
    {
        var sut = Character.Create(healing: healing);
        
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void CannotHealDeadCharacter() {
        var attacker = Character.Create(damage: initialHealth);
        var sut = Character.Create(health: initialHealth);
        
        attacker.Attack(sut);
        
        Assert.That(sut.CanHeal(sut), Is.False);
    }

    [Test]
    public void CanHealDamagedCharacters() {
        var attacker = Character.Create();
        var sut = Character.Create(health: initialHealth);
        
        attacker.Attack(sut);
        
        Assert.That(sut.CanHeal(sut), Is.True);
    }

    [Test]
    public void AccumulativeHealing()
    {
        var attacker = Character.Create();
        var sut = Character.Create(health: initialHealth);
        attacker.Attack(sut);
        attacker.Attack(sut);
        
        sut.Heal();
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }
}