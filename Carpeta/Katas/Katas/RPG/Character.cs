namespace Katas.RPG;

public class Character {
    readonly int maxHealth;
    readonly int damage;
    readonly int healing;
    
    public bool IsAlive => Health > 0;
    public int Level { get; private set; }
    public int Health { get; private set; }

    Character(int health, int damage, int healing, int level) {
        if(health <= 0)
            throw new ArgumentException("Health cannot be less than zero");
        
        Health = maxHealth = health;
        this.damage = damage;
        this.healing = healing;
        this.Level = level;
    }

    public void Attack(Character victim)
    {
        if(!IsAlive)
            throw new InvalidOperationException("A dead character cannot attack");
        if (victim == this)
            throw new InvalidOperationException("Cannot deal damage to itself");
        
        victim.ReceiveDamage(DamageFor(victim));
    }

    int DamageFor(Character victim) {
        return (int)(damage * LevelMultiplier(victim));
    }

    float LevelMultiplier(Character victim) {
        if (Level > victim.Level)
            return 1.5f;

        return 1;
    }

    void ReceiveDamage(int howMuch)
    {
        if (howMuch <= 0)
            throw new ArgumentException("Damage must be greater than 0");
        if (!IsAlive)
            throw new InvalidOperationException("Character is not alive");
        
        Health = int.Max(Health - howMuch, 0);
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