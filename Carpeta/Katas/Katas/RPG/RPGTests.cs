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
//   - Character factory

public class RPGTests {
    [Test]
    public void CharacterIsAlive_ByDefault() {
        var sut = Character.Create();

        Assert.That(sut.IsAlive, Is.True);
    }

    [Test]
    // TODO: Parametrizar daño
    // TODO: Parametrizar vida
    public void DealDamage()
    {
        const int initialHealth = 1000;
        var sut = Character.Create();
        var victim = Character.Create(health: initialHealth);

        sut.Attack(victim);

        Assert.That(victim.Health, Is.LessThan(initialHealth));
    }
}

public class Character {
    public bool IsAlive { get; set; } = true;
    public int Health { get; set; }

    Character(int health) {
        Health = health;
    }

    public void Attack(Character victim)
    {
        victim.Health -= 1;
    }

    public static Character Create(int health = 1000) {
        return new Character(health);
    }
}