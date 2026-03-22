namespace Katas.RPG;

public class Character {
    public bool IsAlive => Health > 0;
    public int Health { get; private set; }
    readonly int maxHealth;
    readonly int damage;
    readonly int healing;

    Character(int health, int damage, int healing) {
        if(health <= 0)
            throw new ArgumentException("Health cannot be less than zero");
        
        Health = maxHealth = health;
        this.damage = damage;
        this.healing = healing;
    }

    public void Attack(Character victim)
    {
        if(!IsAlive)
            throw new InvalidOperationException("A dead character cannot attack");
        if (victim == this)
            throw new InvalidOperationException("Cannot deal damage to itself");
        
        victim.ReceiveDamage(damage);
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
        if (!CanHeal(this)) 
            throw new InvalidOperationException("Cannot heal a character");
        
        Health = int.Min(Health + healing, maxHealth);
    }

    public bool CanHeal(Character other) => other.IsAlive;

    public static Character Create(int health = 1000, int damage = 1, int healing = 1) {
        return new Character(health, damage, healing);
    }
}