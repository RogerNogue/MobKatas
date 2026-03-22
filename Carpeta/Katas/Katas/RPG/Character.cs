namespace Katas.RPG;

public class Character {
    public bool IsAlive => Health > 0;
    public int Health { get; private set; }
    readonly int damage;
    readonly int healing;

    Character(int health, int damage, int healing) {
        Health = health;
        this.damage = damage;
        this.healing = healing;
    }

    public void Attack(Character victim)
    {
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

    public void Heal(Character other) {
        other.Health += healing;
    }

    public static Character Create(int health = 1000, int damage = 1, int healing = 1) {
        return new Character(health, damage, healing);
    }
}