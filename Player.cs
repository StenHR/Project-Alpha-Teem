public class Player
{
    public string Name;
    public int CurrentHitPoints;
    public Weapon? CurrentWeapon;
    public Location CurrentLocation;

    public int Money;
    public int Experience;

    // Player class constructor; When creating the player object the fields name and location are required.
    // Default player health = 100. And the player starts with no money, experience or weapons
    // which can be given to the player later.
    public Player(string name, Location location, int currentHitPoints = 100)
    {
        this.Name = name;
        this.CurrentHitPoints = currentHitPoints;
        this.CurrentWeapon = null;
        this.CurrentLocation = location;
        this.Money = 0;
        this.Experience = 0;

    }

    // Returning simple player stats;
    public string GetPlayerStats() => $"| Name: {this.Name}; Health: {this.CurrentHitPoints}; Money: {this.Money}; EXP: {this.Experience} |";

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
            Console.WriteLine($"You have moved to {CurrentLocation.Name}");
            CurrentLocation.ShowQuests();
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
   }
}