namespace Katas.RPG;

public class Character {
    readonly int maxHealth;
    readonly int healing;
    private readonly int position;

    public bool IsAlive => Health > 0;
    public int Level { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; private set; }

    Character(int health, int damage, int healing, int level, int position) {
        if(health <= 0)
            throw new ArgumentException("Health cannot be less than zero");
        
        Health = maxHealth = health;
        this.Damage = damage;
        this.healing = healing;
        this.Level = level;
        this.position = position;
    }

    public void Attack(Character victim)
    {
        if(!IsAlive)
            throw new InvalidOperationException("A dead character cannot attack");
        if (victim == this)
            throw new InvalidOperationException("Cannot deal damage to itself");

        if (victim.position == 1000)
            return;
        victim.Receive(new Attack(this));
    }

    void Receive(Attack attack)
    {
        if (!IsAlive)
            throw new InvalidOperationException("Character is not alive");

        Health = int.Max(Health - attack.DamageOn(this), 0);
    }

    public void Heal() {
        if (!CanHeal()) 
            throw new InvalidOperationException("Cannot heal a character");
        
        Health = int.Min(Health + healing, maxHealth);
    }

    public bool CanHeal() => IsAlive;

    public static Character Create(int health = 1000, int damage = 1, int healing = 1, int level = 1, int position = 1) {
        return new Character(health, damage, healing, level, position);
    }
}