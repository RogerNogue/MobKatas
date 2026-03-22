namespace Katas.RPG;

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
        victim.ReceiveDamage(damage);
    }

    void ReceiveDamage(int damage) {
        Health -= damage;
        IsAlive = Health > 0;
    }

    public static Character Create(int health = 1000, int damage = 1) {
        return new Character(health, damage);
    }
}