public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public Weapon CurrentWeapon;
    public Location CurrentLocation;
    public List<Weapon> inventory = new() { World.Weapons[0] };
    public Quest? CurrentQuest;

    public int Money;
    public int Experience;

    // Player class constructor; When creating the player object the fields name and location are required.
    // Default player health = 100. And the player starts with no money, experience or weapons
    // which can be given to the player later.
    public Player(string name, Location location, Weapon weaponEquipped = null, int currentHitPoints = 100)
    {
        this.Name = name;
        this.CurrentHitPoints = currentHitPoints;
        this.CurrentWeapon = weaponEquipped;
        this.CurrentLocation = location;
        this.CurrentQuest = null;
        this.Money = 200;
        this.Experience = 0;
    }

    // Returning simple player stats;
    public string GetPlayerStats() => $"| Name: {this.Name}; Health: {this.CurrentHitPoints}; Money: {this.Money}; EXP: {this.Experience} |";

    public void AddInventoryItem(Weapon item)
    {
        this.inventory.Add(item);
    }

    public int? GetInventory()
    {
        Print.Dialog(new string('=', 20));
        Console.WriteLine("Inventory");
        foreach (Weapon weapon in this.inventory)
        {
            string dialog = $"[{weapon.ID}] {weapon.Name}: {weapon.MaximumDamage} [ ]";
            
            if (weapon.ID == this.CurrentWeapon.ID)
            {
                char[] chars = dialog.ToCharArray();
                chars[20] = '*';
                string modified = new string(chars);
                Console.WriteLine(modified);
            }

            Console.WriteLine(dialog);
        }
        Print.Dialog(new string('=', 20));

        Console.WriteLine("\nEnter a number to equip an item >");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int item))
        {
            if (this.inventory.Any(w => w.ID == item))
            {
                return item;
            }
            else
            {
                Console.WriteLine("Invalid selection. Item not found.");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return null;
        }
    }

    public string EquipInventoryItem(int itemId)
    {
        Weapon weapon = this.inventory.Find(w => w.ID == itemId);
        this.CurrentWeapon = weapon;


        if (this.CurrentWeapon == weapon)
        {
            return $"{weapon.Name} is equiped!";
        }
        else
        {
            return "There is no such weapon.";
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
   
   public Quest GetCurrentQuest()
   {
       return CurrentQuest;
   }
}