public class Battle // Initialize a battle together with a while loop: while (Battle.Active...
{
    public Player Self;
    public Monster Enemy;
    public bool Active;

    public Battle(Player player, Monster monster)
    {
        Self = player;
        Enemy = monster;
        Active = true;

        Print.Dialog($"Battle started against {Enemy.Name}!",
            style: Print.PrintStyle.TypeEffect);
    }

    public void PlayerAttack()
    {
        double damage = Self.CurrentWeapon.CalculateDamage();
        Enemy.CurrentHitPoints -= damage;
        Print.Dialog($"{Self.Name} hit {Enemy.Name} for {damage} damage!", 
            style: Print.PrintStyle.TypeEffect);
    }

    public void MonsterAttack()
    {
        double damage = Self.CurrentWeapon.CalculateDamage();
        Enemy.CurrentHitPoints -= damage;
        Print.Dialog($"{Self.Name} hit {Enemy.Name} for {damage} damage!",
            style: Print.PrintStyle.TypeEffect);
    }

    public void Turn()
    {
        if (Self.CurrentHitPoints > 0; Enemy.CurrentHitPoints > 0) {
            PlayerAttack(Self, Enemy);
            MonsterAttack(Enemy, Self);
        } else
        {
            Active = false;
        }
    }
}