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
            Print.ColorMode.Blinking, 
            typeSpeed: 150);
            
        Print.Dialog("A Text Adventure", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Gradient, 
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
                addNewLine: false);
                
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                Print.Dialog("Please enter a name...", 
                    ConsoleColor.Red, 
                    Print.PrintStyle.TypeEffect, 
                    Print.ColorMode.Blinking);
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];
        
        Console.Clear();
        Print.Dialog($"Welcome to the adventure, {player.Name}!", 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Rainbow, 
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
            typeSpeed: 30);
            
        Print.Dialog("OBJECTIVE: Complete all quests to save the town", 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Blinking, 
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
                addNewLine: false);
                
            string input = Console.ReadLine();
            
            ProcessPlayerInput(input, player);
        }
    }

    private static void DisplayGameStatus(Player player)
    {
        Print.Dialog($"PLAYER: {player.Name}", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.TypeEffect, 
            typeSpeed: 20);
            
        Print.Dialog("LOCATION: ", 
            ConsoleColor.Magenta, 
            Print.PrintStyle.TypeEffect, 
            typeSpeed: 20, 
            addNewLine: false);
            
        Print.Dialog(player.CurrentLocation.Name, 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Blinking, 
            typeSpeed: 40);
            
        Print.Dialog(player.CurrentLocation.Description, 
            ConsoleColor.White, 
            Print.PrintStyle.TypeEffect, 
            typeSpeed: 30);
    }

    private static void DisplayNavigationOptions(Player player)
    {
        Print.Dialog("ACTIONS:", 
            ConsoleColor.Yellow);
            
        if (player.CurrentLocation.LocationToNorth != null)
            Print.Dialog("[1] Go North", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToWest != null)
            Print.Dialog("[2] Go West", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToEast != null)
            Print.Dialog("[3] Go East", 
                ConsoleColor.Cyan);
                
        if (player.CurrentLocation.LocationToSouth != null)
            Print.Dialog("[4] Go South", 
                ConsoleColor.Cyan);
                
        Print.Dialog("[5] Show and pick quests", 
            ConsoleColor.Green);
            
        Print.Dialog("[6] Show inventory", 
            ConsoleColor.Green);
    }

    private static void ProcessPlayerInput(string input, Player player)
    {
        switch (input.ToLower())
        {
            case "1":
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
                        Print.ColorMode.Blinking);
                    Thread.Sleep(1000);
                }
                break;
                
            case "2":
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
                        Print.ColorMode.Blinking);
                    Thread.Sleep(1000);
                }
                break;
                
            case "3":
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
                        Print.ColorMode.Blinking);
                    Thread.Sleep(1000);
                }
                break;
                
            case "4":
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
                        Print.ColorMode.Blinking);
                    Thread.Sleep(1000);
                }
                break;
                
            case "5":
                Console.Clear();
                Location currentLocation = player.CurrentLocation;
                currentLocation.ShowQuests();
                
                if (currentLocation.QuestAvailableHere?.Any() != true)
                {
                    Print.Dialog("Press any key to continue...", 
                        ConsoleColor.DarkGray);
                    Console.ReadKey();
                    break;
                }
                
                Quest pickedQuest = currentLocation.PickQuest();
                if (pickedQuest != null)
                {
                    pickedQuest.QuestLine.RunQuest();
                }
                Thread.Sleep(1000);
                break;
                
            case "6":
                Console.Clear();
                Print.Dialog("INVENTORY", 
                    ConsoleColor.Yellow, 
                    Print.PrintStyle.TypeEffect, 
                    Print.ColorMode.Gradient);
                
                // TODO: inventory logica hieerrr...
                
                Print.Dialog("Press any key to continue...", 
                    ConsoleColor.DarkGray);
                Console.ReadKey();
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