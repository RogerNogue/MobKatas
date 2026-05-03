namespace Katas.RPG;
/*
    - Characters have an attack Max Range.

    - Melee fighters have a range of 2 meters.

    - Ranged fighters have a range of 20 meters.

    - Characters must be in range to deal damage to a target.
 */
public class AttackTests {
    [Test]
    public void CharacterIsAlive_ByDefault() {
        var sut = Character.Create();

        Assert.That(sut.IsAlive, Is.True);
    }

    [Test]
    public void CharacterIsLevel1ByDefault()
    {
        var sut = Character.Create();

        Assert.That(sut.Level, Is.EqualTo(1));
    }

    [Test]
    public void DealDamage()
    {
        var sut = Character.Create(damage: 6);
        var victim = Character.Create(health: 1000);

        sut.Attack(victim);

        Assert.That(victim.Health, Is.EqualTo(1000 - 6));
    }

    [Test]
    public void Kill()
    {
        var sut = Character.Create(damage: 1000);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.False);
    }

    [Test]
    public void DealsDamageButDoesNotKill()
    {
        var sut = Character.Create(damage: 1000 - 1);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.True);
    }

    [Test]
    public void DamageIsAccumulative()
    {
        var sut = Character.Create(damage: 6);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - (6*2)));
    }

    [Test]
    public void HealthCannotBeNegative()
    {
        var sut = Character.Create(damage: 1000*2);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(0));
    }

    [Test]
    public void Character5LevelsAboveDealsExtraDamage()
    {
        var sut = Character.Create(damage: 6, level: 6);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6 * 1.5f));
    }
    
    [Test]
    public void DoNotDealExtraDamageUntil5LevelsOrAbove()
    {
        var sut = Character.Create(damage: 6, level: 5);
        var victim = Character.Create(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6));
    }
    
    [Test]
    public void Character5LevelsBelowDealsLessDamage()
    {
        var sut = Character.Create(damage: 6);
        var victim = Character.Create(health: 1000, level: 6);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6 * .5f));
    }

    [Test]
    public void FarVictimDoesNotReceiveDamage()
    {
        var sut = Character.Create(position: 1 );
        var victim = Character.Create(health: 1000, position: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000));
    }
}