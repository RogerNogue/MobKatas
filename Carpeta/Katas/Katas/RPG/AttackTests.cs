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
        var sut = Character.Melee();

        Assert.That(sut.IsAlive, Is.True);
    }

    [Test]
    public void CharacterIsLevel1ByDefault()
    {
        var sut = Character.Melee();

        Assert.That(sut.Level, Is.EqualTo(1));
    }

    [Test]
    public void DealDamage()
    {
        var sut = Character.Melee(damage: 6);
        var victim = Character.Melee(health: 1000);

        sut.Attack(victim);

        Assert.That(victim.Health, Is.EqualTo(1000 - 6));
    }

    [Test]
    public void Kill()
    {
        var sut = Character.Melee(damage: 1000);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.False);
    }

    [Test]
    public void DealsDamageButDoesNotKill()
    {
        var sut = Character.Melee(damage: 1000 - 1);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.IsAlive, Is.True);
    }

    [Test]
    public void DamageIsAccumulative()
    {
        var sut = Character.Melee(damage: 6);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - (6*2)));
    }

    [Test]
    public void HealthCannotBeNegative()
    {
        var sut = Character.Melee(damage: 1000*2);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(0));
    }

    [Test]
    public void Character5LevelsAboveDealsExtraDamage()
    {
        var sut = Character.Melee(damage: 6, level: 6);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6 * 1.5f));
    }
    
    [Test]
    public void DoNotDealExtraDamageUntil5LevelsOrAbove()
    {
        var sut = Character.Melee(damage: 6, level: 5);
        var victim = Character.Melee(health: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6));
    }
    
    [Test]
    public void Character5LevelsBelowDealsLessDamage()
    {
        var sut = Character.Melee(damage: 6);
        var victim = Character.Melee(health: 1000, level: 6);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000 - 6 * .5f));
    }
    
    asdkfjsalkfjas
    // NOS HEMOS QUEDADO POR AQUÍ (Iteración 3 - Rango)
    // No podemos tener el concepto de posición en los characters como tal, pensamos en extraer un "mapa" que conozca dónde está cada uno.
    // Pero eso rompería muchos tests, hay que darle una vuelta.

    [Test]
    public void FarVictimDoesNotReceiveDamage()
    {
        var sut = Character.Melee(position: 1);
        var victim = Character.Melee(health: 1000, position: 1000);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000));
    }
    
    [Test]
    public void DealDamageWithinRange()
    {
        var sut = Character.Melee(position: 1);
        var victim = Character.Melee(health: 1000, position: 2);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.Not.EqualTo(1000));
    }

    [Test]
    public void MeleeFighterDoesNotReachFurtherVictim()
    {
        var sut = Character.Melee(position: 1);
        var victim = Character.Melee(health: 1000, position: 20);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(1000));
    }
    
    [Test]
    public void RangedFighterReachesFurtherVictim()
    {
        var sut = Character.Ranged(position: 1);
        var victim = Character.Melee(health: 1000, position: 20);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.Not.EqualTo(1000));
    }
    
    [Test]
    public void CanAttackEnemyAtMaxRange()
    {
        var sut = Character.Ranged(position: 0);
        var victim = Character.Melee(health: 1000, position: 20);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.Not.EqualTo(1000));
    }
}