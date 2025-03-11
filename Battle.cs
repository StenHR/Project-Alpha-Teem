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
            style: Print.PrintStyle.TypeEffect,
            color: ConsoleColor.Yellow);
    }

    public void PlayerAttack()
    {   
        // Check to make the sword of spider slaying one shot.
        if (Self.CurrentWeapon.ID == World.WEAPON_ID_SWORD_OF_SPIDER_SLAYING && Enemy.ID == World.MONSTER_ID_GIANT_SPIDER)
        {
            Enemy.CurrentHitPoints = 0;
            Print.Dialog($"You used the Sword of Spider Slaying and one shot the {Enemy.Name}!", ConsoleColor.Green);
        }
        else
        {
            int damage = Self.CurrentWeapon.CalculateDamage();
            Enemy.CurrentHitPoints -= Convert.ToInt32(damage);
            Print.Dialog($"{Self.Name} hit {Enemy.Name} for {damage} damage!", 
                style: Print.PrintStyle.TypeEffect,
                color: ConsoleColor.Green);
        }
    }

    public void MonsterAttack()
    {
        if (Enemy.CurrentHitPoints > 0)
        {
            int damage = Enemy.CalculateDamage();
            Self.CurrentHitPoints -= Convert.ToInt32(damage);
            Print.Dialog($"{Enemy.Name} hit {Self.Name} for {damage} damage!",
                style: Print.PrintStyle.TypeEffect,
                color: ConsoleColor.Red);
        }
    }

    public string Info()
    {
        Self.CurrentHitPoints = Self.CurrentHitPoints < 0 ? 0 : Self.CurrentHitPoints;
        Enemy.CurrentHitPoints = Enemy.CurrentHitPoints < 0 ? 0 : Enemy.CurrentHitPoints;

        return $"{Self.GetPlayerStats()}\n{Enemy.GetMonsterStats()}";
    }

    public void Turn()
    {
        if (Self.CurrentHitPoints > 0 && Enemy.CurrentHitPoints > 0) {
            PlayerAttack();
            MonsterAttack();
            Console.WriteLine(Info());
        } else if (Self.CurrentHitPoints <= 0)
        {
            this.Active = false;
            Self.Die();
        } else if (Enemy.CurrentHitPoints <= 0)
        {
            Print.Dialog($"{Self.Name} has defeated {Enemy.Name}!",
                style: Print.PrintStyle.TypeEffect,
                color: ConsoleColor.Green);
         
            this.Active = false;
        }
        Thread.Sleep(200);
    }
}