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
//   - Is alive by default
//   - Starts at level 1
//   - Deal damage
//   - Kill
//   - Heal
//   - Dead characters cannot be healed
//   - Healing capped to max health (1000)

public class RPGTests {
    [Test]
    public void CharacterIsAlive_ByDefault() {
        var sut = new Character();

        Assert.That(sut.IsAlive, Is.True);
    } 
}

public class Character {
    public bool IsAlive { get; set; } = true;
}