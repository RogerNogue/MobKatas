namespace Katas.RPG;

// - Health, starting at 1000
//     - Level, starting at 1
//     - May be Alive or Dead, starting Alive (Alive may be a true/false)

// - Damage is subtracted from Health
//     - When damage received exceeds current Health, Health becomes 0 and the character dies

// A Character can Heal a Character.
//     - Dead characters cannot be healed
//     - Healing cannot raise health above 1000

// Character
//   x Is alive by default
//   - Starts at level 1?
//   x Deal damage
//   x Damage is accumulative
//   x Health cannot be negative
//   x Kill
//   - Heal
//   - Dead characters cannot be healed
//   - Healing capped to max health (1000)
//   x Character factory
//   - Character with less than 0 health can not be created

public class RPGTests {
    const int initialHealth = 1000;
    const int damage = 5;
    
    [Test]
    public void CharacterIsAlive_ByDefault() {
        var sut = Character.Create();

        Assert.That(sut.IsAlive, Is.True);
    }

    [Test]
    public void DealDamage()
    {
        var sut = Character.Create(damage: damage);
        var victim = Character.Create(health: initialHealth);

        sut.Attack(victim);

        Assert.That(victim.Health, Is.EqualTo(initialHealth - damage));
    }

    [Test]
    public void Kill()
    {
        var sut = Character.Create(damage: initialHealth);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.False);
    }

    [Test]
    public void DealsDamageButDoesNotKill()
    {
        var sut = Character.Create(damage: initialHealth - 1);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.True);
    }

    [Test]
    public void DamageIsAccumulative()
    {
        var sut = Character.Create(damage: damage);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth - (damage*2)));
    }

    [Test]
    public void HealthCannotBeNegative()
    {
        var sut = Character.Create(damage: initialHealth*2);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(0));
    }

    [Test]
    public void HealAnotherCharacter() 
    {
        var sut = Character.Create(damage: damage);
        var victim = Character.Create(damage: initialHealth);
        sut.Attack(victim);
        
        sut.Heal(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth));
    }
}