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
        int damage = Self.CurrentWeapon.CalculateDamage();
        Enemy.CurrentHitPoints -= Convert.ToInt32(damage);
        Print.Dialog($"{Self.Name} hit {Enemy.Name} for {damage} damage!", 
            style: Print.PrintStyle.TypeEffect);
    }

    public void MonsterAttack()
    {
        int damage = Self.CurrentWeapon.CalculateDamage();
        Self.CurrentHitPoints -= Convert.ToInt32(damage);
        Print.Dialog($"{Enemy.Name} hit {Self.Name} for {damage} damage!",
            style: Print.PrintStyle.TypeEffect);
    }

    public string Info() => $"{Self.GetPlayerStats()}\n{Enemy.GetMonsterStats()}";

    public void Turn()
    {
        if (Self.CurrentHitPoints > 0 && Enemy.CurrentHitPoints > 0) {
            PlayerAttack();
            MonsterAttack();
            Console.WriteLine(Info());
        } else
        { 
            Active = false;
        }
    }
}