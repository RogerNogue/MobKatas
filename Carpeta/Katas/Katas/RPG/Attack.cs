namespace Katas.RPG;

public class Attack(Character attacker)
{
    private const float BaseDamageMultiplier = 1;
    private const float OverlevelDamageMultiplier = 1.5f;
    private const float UnderlevelDamageMultiplier = 0.5f;
    private const int DamageMultiplierLevelThreshold = 5;

    public int DamageOn(Character victim) {
        var result = (int)(attacker.Damage * LevelMultiplier(victim, attacker.Level));
        
        if (result <= 0)
            throw new ArgumentException("Damage must be greater than 0");

        return result;
    }

    private float LevelMultiplier(Character victim, int level) {
        if (level >= victim.Level + DamageMultiplierLevelThreshold)
            return OverlevelDamageMultiplier;
        
        if (level <= victim.Level - DamageMultiplierLevelThreshold)
            return UnderlevelDamageMultiplier;

        return BaseDamageMultiplier;
    }
}