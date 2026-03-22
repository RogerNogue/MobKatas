namespace Katas.RPG;
/*
    - When dealing damage: 
        - If the target is 5 or more Levels above the attacker, Damage is reduced by 50% 
        - If the target is 5 or more Levels below the attacker, Damage is increased by 50%
 */
public class AttackTests {
    const int initialHealth = 1000;
    const int damage = 6;
    
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
    public void Character5LevelsAboveDealsExtraDamage()
    {
        var sut = Character.Create(damage: damage, level: 6);
        var victim = Character.Create(health: initialHealth, level: 1);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth - damage * 1.5f));
    }
    
    [Test]
    public void DoNotDealExtraDamageUntil5LevelsOrAbove()
    {
        var sut = Character.Create(damage: damage, level: 5);
        var victim = Character.Create(health: initialHealth, level: 1);
        
        sut.Attack(victim);
        
        Assert.That(victim.Health, Is.EqualTo(initialHealth - damage));
    }
}