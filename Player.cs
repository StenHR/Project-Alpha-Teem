public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public Quest CurrentQuest;
    public List<Item> Inventory = new() { World.Weapons[0] };
    public int Money;
    public int Experience;
    public bool Alive;

    // Player class constructor; When creating the player object the fields name and location are required.
    // Default player health = 100. And the player starts with no money, experience or weapons
    // which can be given to the player later.
    public Player(string name, Location location, Weapon weaponEquipped = null, int currentHitPoints = 100)
    {
        this.Name = name;
        this.CurrentHitPoints = currentHitPoints;
        this.CurrentWeapon = weaponEquipped;
        this.CurrentLocation = location;
        this.Money = 300;
        this.CurrentQuest = null;
        this.Experience = 0;
        this.Alive = true;
    }

    // Returning simple player stats;
    public string GetPlayerStats() => $"| Name: {this.Name}; Health: {this.CurrentHitPoints}; Money: {this.Money}; EXP: {this.Experience} |";

    public void AddInventoryItem(Item item)
    {
        this.Inventory.Add(item);
    }

    public void GetInventory()
    {
        Print.Dialog(new string('=', 20));
        for (int i = 0; i < this.Inventory.Count; i++)
        {
            string dialog = $"[{i}] {this.Inventory[i].Name} | dmg: {(this.Inventory[i] is Weapon weapon ? $"{weapon.MaximumDamage}" : "")}";

            if (this.Inventory[i] is Weapon weaponItem)
            {
                if (weaponItem.IsEquipped)
                {
                    dialog += " [*]";
                }
            }

            Console.WriteLine(dialog);
        }
        Print.Dialog("[*] -> currently equipped.", ConsoleColor.DarkGray);
        Print.Dialog(new string('=', 20));

    }

    public void EquipInventoryItem()
    {

        if (this.Inventory.Count == 0)
        {
            Print.Dialog("Your Inventory is empty.", ConsoleColor.Red);
            Thread.Sleep(1000);
            return;
        }

        Print.Dialog("Select the item to equip:", ConsoleColor.Cyan);

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < this.Inventory.Count)
        {
            if (this.Inventory[choice] is Weapon selectedWeapon)
            {
                this.CurrentWeapon.IsEquipped = false;
                this.CurrentWeapon = selectedWeapon;
                this.CurrentWeapon.IsEquipped = true;
                Print.Dialog($"You have equipped {selectedWeapon.Name}.", ConsoleColor.Green);
            }
            else
            {
                Print.Dialog("You can only equip weapons.", ConsoleColor.Red);
                Thread.Sleep(1000);
            }
        }
        else
        {
            Print.Dialog("Invalid choice.", ConsoleColor.Red);
            Thread.Sleep(1000);
        }
        
    }

    // Receiving rewards for finishing quests;
    public string ReceiveQuestRewards(int money = 0, int experience = 0)
    {
        this.Money += money;
        this.Experience += experience;

        if (money == 0)
        {
            return $"Hooray! You received {experience} experience!";
        }

        if (experience == 0)
        {
            return $"Hooray! You received {money} coin(s)!";
        }

        return $"Hooray! You received {money} coin(s), and {experience} experience!";

    }
   
   //Movement
   public void Move(string direction)
   {
        Location newLocation = direction.ToLower() switch
        {
            "north" => CurrentLocation.LocationToNorth,
            "south" => CurrentLocation.LocationToSouth,
            "east"  => CurrentLocation.LocationToEast,
            "west"  => CurrentLocation.LocationToWest,
            _ => null
        };

        if (newLocation != null)
        {
            CurrentLocation = newLocation;
            Print.Dialog($"You have moved to {CurrentLocation.Name}");
            Print.Dialog(CurrentLocation.ShowDescription());
        }
        else
        {
            Print.Dialog("You can't go that way.");
        }
   }

    public void Die()
    {
        this.Alive = false;
        Print.Dialog("You died......",
            style: Print.PrintStyle.TypeEffect,
            color: ConsoleColor.DarkRed,
            typeSpeed: 40);
        Print.Dialog("The villagers saw you lying on the ground and decided to bring you back to town...",
            style: Print.PrintStyle.TypeEffect,
            typeSpeed: 80,
            color: ConsoleColor.Red);

        this.Experience -= 10;
        this.CurrentLocation = World.LocationByID(1);
        this.CurrentHitPoints = 100;
    }
   
   public Quest GetCurrentQuest()
   {
       return CurrentQuest;
   }
}