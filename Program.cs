class Program
{
    public static void Main()
    {
        Opening();
    }

    public static void Opening()
    {
        Console.Clear();
        Print.Dialog("SPIDER HUNTER", 
            ConsoleColor.Red, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Single, 
            typeSpeed: 150);
            
        Print.Dialog("A Text Adventure", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Single, 
            typeSpeed: 80);
            
        Print.Dialog(new string('=', 50), 
            ConsoleColor.DarkGray);
        
        string name;
        do
        {
            Print.Dialog("Welcome, brave adventurer! What is thy name? ", 
                ConsoleColor.Cyan, 
                Print.PrintStyle.TypeEffect, 
                typeSpeed: 40, 
                addNewLine: true);
                
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                Print.Dialog("Please enter a name...", 
                    ConsoleColor.Red, 
                    Print.PrintStyle.TypeEffect, 
                    Print.ColorMode.Single);
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];
        World.AddPlayer(player);
        
        Console.Clear();
        Print.Dialog($"Welcome to the adventure, {player.Name}!", 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Single, 
            typeSpeed: 40);
            
        Thread.Sleep(1000);
        Console.Clear();
        
        Print.Dialog("THE SITUATION:", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.TypeEffect);
            
        Print.Dialog("The people in town are being terrorized by giant spiders.", 
            ConsoleColor.White, 
            Print.PrintStyle.TypeEffect, 
            typeSpeed: 30);
            
        Print.Dialog("You have decided to do what you can to help.", 
            ConsoleColor.White, 
            Print.PrintStyle.TypeEffect, 
            typeSpeed: 30,
            addNewLine: true);
            
        Print.Dialog("OBJECTIVE: Complete all quests to save the town", 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Single, 
            typeSpeed: 40);
            
        Thread.Sleep(2000);

        var gameRunning = true;
        while (gameRunning)
        {
            Console.Clear();
            DisplayGameStatus(player);

            Print.Dialog(new string('-', 50), 
                ConsoleColor.DarkGray);
                
            DisplayNavigationOptions(player);
            
            Print.Dialog(new string('-', 50), 
                ConsoleColor.DarkGray);
                
            Print.Dialog("What would you like to do? ", 
                ConsoleColor.Cyan, 
                Print.PrintStyle.TypeEffect, 
                typeSpeed: 20, 
                addNewLine: true);
                
            string input = Console.ReadLine();
            
            ProcessPlayerInput(input, player);
        }
    }

    private static void DisplayGameStatus(Player player)
    {
        Print.Dialog($"PLAYER: {player.Name}", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.Instant, 
            typeSpeed: 20);

        Print.Dialog($"Health: {player.CurrentHitPoints}",
            ConsoleColor.Red,
            Print.PrintStyle.Instant,
            typeSpeed: 20);

        Print.Dialog($"Money: {player.Money}",
            ConsoleColor.Yellow,
            Print.PrintStyle.Instant,
            typeSpeed: 20);

        Print.Dialog($"Experience: {player.Experience}",
            ConsoleColor.Blue,
            Print.PrintStyle.Instant,
            typeSpeed: 20);

        Print.Dialog("LOCATION: ", 
            ConsoleColor.Magenta, 
            Print.PrintStyle.Instant, 
            typeSpeed: 20, 
            addNewLine: false);
            
        Print.Dialog(player.CurrentLocation.Name, 
            ConsoleColor.Magenta, 
            Print.PrintStyle.Instant,  
            typeSpeed: 40);
            
        Print.Dialog(player.CurrentLocation.Description, 
            ConsoleColor.White, 
            Print.PrintStyle.Instant, 
            typeSpeed: 30);
    }

    private static void DisplayNavigationOptions(Player player)
    {
        Print.Dialog("ACTIONS:", 
            ConsoleColor.Yellow);
            
        if (player.CurrentLocation.LocationToNorth != null)
            Print.Dialog("[W] Go North", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToWest != null)
            Print.Dialog("[A] Go West", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToSouth != null)
            Print.Dialog("[S] Go South", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToEast != null)
            Print.Dialog("[D] Go East", 
                ConsoleColor.Cyan);
        
        Print.Dialog("[I] Inventory", 
            ConsoleColor.Green);
        
        if (player.CurrentLocation == World.LocationByID(World.LOCATION_ID_TOWN_SQUARE))
        {
            Print.Dialog("[E] Enter Store", 
                ConsoleColor.Yellow, 
                Print.PrintStyle.TypeEffect, 
                Print.ColorMode.Single);
        }
        
        Print.Dialog("[L] Quest Log", 
            ConsoleColor.Green);
    }

    private static void ProcessPlayerInput(string input, Player player)
    {
        switch (input.ToLower())
        {
            case "w":
                if (player.CurrentLocation.LocationToNorth != null)
                {
                    player.Move("north");
                }
                else
                {
                    Console.Clear();
                    Print.Dialog("You cannot go that way!", 
                        ConsoleColor.Red, 
                        Print.PrintStyle.TypeEffect, 
                        Print.ColorMode.Single);
                    Thread.Sleep(1000);
                }
                break;
                
            case "a":
                if (player.CurrentLocation.LocationToWest != null)
                {
                    player.Move("west");
                }
                else
                {
                    Console.Clear();
                    Print.Dialog("You cannot go that way!", 
                        ConsoleColor.Red, 
                        Print.PrintStyle.TypeEffect, 
                        Print.ColorMode.Single);
                    Thread.Sleep(1000);
                }
                break;
                
            case "d":
                if (player.CurrentLocation.LocationToEast != null)
                {
                    player.Move("east");
                }
                else
                {
                    Console.Clear();
                    Print.Dialog("You cannot go that way!", 
                        ConsoleColor.Red, 
                        Print.PrintStyle.TypeEffect, 
                        Print.ColorMode.Single);
                    Thread.Sleep(1000);
                }
                break;
                
            case "s":
                if (player.CurrentLocation.LocationToSouth != null)
                {
                    player.Move("south");
                }
                else
                {
                    Console.Clear();
                    Print.Dialog("You cannot go that way!", 
                        ConsoleColor.Red, 
                        Print.PrintStyle.TypeEffect, 
                        Print.ColorMode.Single);
                    Thread.Sleep(1000);
                }
                break;
                
            case "l":
                Console.Clear();
                player.CurrentLocation.ShowQuests();
                player.CurrentQuest = player.CurrentLocation.PickQuest();
                if(player.CurrentQuest != null)
                    player.CurrentQuest.QuestLine.RunQuest();
                break;
                
            case "i":
                Console.Clear();
                Print.Dialog("INVENTORY", 
                    ConsoleColor.Yellow, 
                    Print.PrintStyle.TypeEffect, 
                    Print.ColorMode.Single);
                
                player.GetInventory();

                string answer;
                do
                {
                    Print.Dialog("Do you also want to equip an item? [y/n]", color: ConsoleColor.Green);
                    answer = Console.ReadLine().ToLower();
                }
                while (string.IsNullOrWhiteSpace(answer));

                if(answer == "n")
                {
                    break;
                }

                player.EquipInventoryItem();
                
                Print.Dialog("Press any key to continue...", 
                    ConsoleColor.DarkGray);
                Console.ReadKey();
                break;
            
            case "e":
                if (player.CurrentLocation == World.LocationByID(World.LOCATION_ID_TOWN_SQUARE))
                {
                    Shop.VisitShop(player);
                }
                else
                {
                    Console.Clear();
                    Print.Dialog("There is no shop here!", 
                        ConsoleColor.Red, 
                        Print.PrintStyle.TypeEffect);
                    Thread.Sleep(1000);
                }
                break;
                
            default:
                Console.Clear();
                Print.Dialog("Invalid command. Please try again.", 
                    ConsoleColor.Red, 
                    Print.PrintStyle.TypeEffect);
                Thread.Sleep(1000);
                break;
        }
    }
}
