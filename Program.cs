class Program
{
    public static void Main()
    {
        Opening();
    }


    public static void Opening()
    {
        
        string name;

        do
        {
            Print.Dialog("Welcome, player! What is thy name? ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Print.Dialog("Please enter a name...");
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];
        Console.Clear();
        Print.Dialog($"Hello there {player.Name}!");
        Print.Dialog("Here's thy deal... The people in town are being terrorized by giant spiders.\n" +
            "You decide to do what you can to help. \n\r\nObjective: complete all quests",
            style: Print.PrintStyle.TypeEffect);

        var x = true;
        while (x)
        {
            Print.Dialog("[1] Go North");
            Print.Dialog("[2] Go West");
            Print.Dialog("[3] Go East");
            Print.Dialog("[4] Go South");
            Print.Dialog("[5] Description");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                    player.Move("north");
                    Console.Clear();
                    continue;
                case "2":
                    player.Move("west");
                    Console.Clear();
                    continue;
                case "3":
                    player.Move("east");
                    Console.Clear();
                    continue;
                case "4":
                    player.Move("south");
                    Console.Clear();
                    continue;
                case "5":
                    Print.Dialog(startLocation.Description);
                    Location currentLocation = player.CurrentLocation;
                    currentLocation.ShowQuests();
                    currentLocation.PickQuest();
                    
                    continue;
                default:
                    continue;
            }
        }
    }
}