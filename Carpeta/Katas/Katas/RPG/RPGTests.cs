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
//   - Kill
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
        var sut = Character.Create(damage: damage);
        var victim = Character.Create(health: initialHealth);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.True);
    }
}

public class Character {
    public bool IsAlive { get; set; } = true;
    public int Health { get; private set; }
    readonly int damage;

    Character(int health, int damage) {
        Health = health;
        this.damage = damage;
    }

    public void Attack(Character victim)
    {
        victim.Health -= damage;
        victim.IsAlive = victim.Health > 0;
    }

    public static Character Create(int health = 1000, int damage = 1) {
        return new Character(health, damage);
    }
}