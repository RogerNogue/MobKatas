namespace Katas.RPG;

public class HealingTests
{
    const int initialHealth = 1000;
    const int healing = 1;
    
    [Test]
    public void HealAnotherCharacter() 
    {
        var attacker = Character.Melee(damage: healing);
        var sut = Character.Melee(healing: healing);
        attacker.Attack(sut);
        
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void HealthIsCappedAtInitialHealth()
    {
        var sut = Character.Melee(healing: healing);
        
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }

    [Test]
    public void CannotHealDeadCharacter() {
        var attacker = Character.Melee(damage: initialHealth);
        var sut = Character.Melee(health: initialHealth);
        
        attacker.Attack(sut);
        
        Assert.That(sut.CanHeal(), Is.False);
    }

    [Test]
    public void CanHealDamagedCharacters() {
        var attacker = Character.Melee();
        var sut = Character.Melee(health: initialHealth);
        
        attacker.Attack(sut);
        
        Assert.That(sut.CanHeal(), Is.True);
    }

    [Test]
    public void AccumulativeHealing()
    {
        var attacker = Character.Melee();
        var sut = Character.Melee(health: initialHealth);
        attacker.Attack(sut);
        attacker.Attack(sut);
        
        sut.Heal();
        sut.Heal();
        
        Assert.That(sut.Health, Is.EqualTo(initialHealth));
    }
}