namespace Katas.RPG;

public class Attack(Character attacker)
{
    private const float BaseDamageMultiplier = 1;
    private const float OverlevelDamageMultiplier = 1.5f;
    private const float UnderlevelDamageMultiplier = 0.5f;
    private const int DamageMultiplierLevelThreshold = 5;

    public int DamageOn(Character victim) {
        return (int)(attacker.Damage * LevelMultiplier(victim, attacker.Level));
    }

    private float LevelMultiplier(Character victim, int level) {
        if (level >= victim.Level + DamageMultiplierLevelThreshold)
            return OverlevelDamageMultiplier;
        
        if (level <= victim.Level - DamageMultiplierLevelThreshold)
            return UnderlevelDamageMultiplier;

        return BaseDamageMultiplier;
    }
}

public class Character {
    readonly int maxHealth;
    readonly int healing;

    public bool IsAlive => Health > 0;
    public int Level { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; private set; }

    Character(int health, int damage, int healing, int level) {
        if(health <= 0)
            throw new ArgumentException("Health cannot be less than zero");
        
        Health = maxHealth = health;
        this.Damage = damage;
        this.healing = healing;
        this.Level = level;
    }

    public void Attack(Character victim)
    {
        if(!IsAlive)
            throw new InvalidOperationException("A dead character cannot attack");
        if (victim == this)
            throw new InvalidOperationException("Cannot deal damage to itself");
        
        victim.Receive(new Attack(this));
    }

    void Receive(Attack attack)
    {
        var damage = attack.DamageOn(this);
        if (damage <= 0)
            throw new ArgumentException("Damage must be greater than 0");
        if (!IsAlive)
            throw new InvalidOperationException("Character is not alive");
        
        Health = int.Max(Health - damage, 0);
    }

    public void Heal() {
        if (!CanHeal()) 
            throw new InvalidOperationException("Cannot heal a character");
        
        Health = int.Min(Health + healing, maxHealth);
    }

    public bool CanHeal() => IsAlive;

    public static Character Create(int health = 1000, int damage = 1, int healing = 1, int level = 1) {
        return new Character(health, damage, healing, level);
    }
}