public class Battle
{
    public Player Self;
    public Monster Enemy;
    public bool Active;
    public bool PossibleRunAway;

    public Battle(Player player, Monster monster)
    {
        Self = player;
        Enemy = monster;
        Active = true;
        PossibleRunAway = true;


        Print.Dialog($"Battle started against {Enemy.Name}!",
            style: Print.PrintStyle.TypeEffect,
            color: ConsoleColor.Yellow);
    }

    public void PlayerAttack()
    {
        if (Self.CurrentWeapon.ID == World.WEAPON_ID_SWORD_OF_SPIDER_SLAYING && Enemy.ID == World.MONSTER_ID_GIANT_SPIDER)
        {
            Enemy.CurrentHitPoints = 0;
            Print.Dialog($"You used the Sword of Spider Slaying and one shot the {Enemy.Name}!", ConsoleColor.Green);
        }
        else
        {
            int damage = Self.CurrentWeapon.CalculateDamage();
            Enemy.CurrentHitPoints -= Convert.ToInt32(damage);
            Print.Dialog($"{Self.Name} hit {Enemy.Name} with {Self.CurrentWeapon.Name} for {damage} damage!",
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

    public void BattleMenu()
    {
        string action;
        Console.WriteLine("\n");
        Print.Dialog("Choose your action:");
        Print.Dialog("[s] Switch weapon", ConsoleColor.Yellow);
        Print.Dialog("[a] Attack", ConsoleColor.Red);
        if (this.PossibleRunAway)
        {
            Print.Dialog("[r] Run (5% success rate)", ConsoleColor.Cyan);
        }
        

        action = Console.ReadLine().ToLower();

        switch (action)
        {
            case "s":
                this.Self.GetInventory();
                this.Self.EquipInventoryItem();
                break;
            case "a":
                if (Chance())
                {
                    Turn();
                }
                else
                {
                    Print.Dialog($"You weren't quick enough to attack. {Enemy.Name} attacked you first, this staggered you.", ConsoleColor.Red);
                    ReversedTurn();
                }
                break;
            case "r":
                if (this.PossibleRunAway)
                {
                    if (Chance())
                    {
                        Print.Dialog("You sucesfully ran away!", ConsoleColor.Green);
                        Thread.Sleep(1000);
                        this.Active = false;
                    }
                    else
                    {
                        Print.Dialog("Your attempt to run away has failed!", ConsoleColor.Red);
                        this.PossibleRunAway = false;
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Print.Dialog("You can't run away anymore..", ConsoleColor.Red);
                    Thread.Sleep(1000);
                }
                break;
            default:
                Print.Dialog("Choose a valid action.", ConsoleColor.Red);
                break;
        }
    }

    public bool Chance()
    {
        Random random = new Random();
        return random.Next(1, 21) == 1;
    }

    public void Turn()
    {
        if (Self.CurrentHitPoints > 0 && Enemy.CurrentHitPoints > 0)
        {
            PlayerAttack();
            MonsterAttack();
            Console.WriteLine(Info());
        }
        CheckHealthStatuses();
        Thread.Sleep(200);
    }

    public void ReversedTurn()
    {
        if (Self.CurrentHitPoints > 0 && Enemy.CurrentHitPoints > 0)
        {
            MonsterAttack();
            Console.WriteLine(Info());
        }
        CheckHealthStatuses();
        Thread.Sleep(200);
    }

    public void CheckHealthStatuses()
    {
        if (Self.CurrentHitPoints <= 0)
        {
            this.Active = false;
            Self.Die();
        }

        if (Enemy.CurrentHitPoints <= 0)
        {
            Print.Dialog($"{Self.Name} has defeated {Enemy.Name}!",
                style: Print.PrintStyle.TypeEffect,
                color: ConsoleColor.Green);

            Console.WriteLine(Info());
            this.Active = false;
        }
    }
}