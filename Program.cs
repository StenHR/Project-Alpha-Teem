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
            Print.Dialog("Welcome, player! What is thy name? ", style: Print.PrintStyle.TypeEffect);
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Print.Dialog("Please enter a name...", color: ConsoleColor.Red);
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];

        Print.Dialog($"Hello there {player.Name}!", style: Print.PrintStyle.TypeEffect);
        Print.Dialog("Here's thy deal... The people in town are being terrorized by giant spiders.\n" +
            "You decide to do what you can to help. \n\r\nObjective: complete all quests",style: Print.PrintStyle.TypeEffect);

        var x = true;
        while (x)
        {
            Console.WriteLine();

            if (player.CurrentLocation.LocationToNorth != null)
            {
            Console.WriteLine($"[W] Go North");
            }
            if (player.CurrentLocation.LocationToWest != null)
            {
            Console.WriteLine($"[A] Go West");
            }
            if (player.CurrentLocation.LocationToSouth != null)
            {
            Console.WriteLine($"[S] Go South");
            }
            if (player.CurrentLocation.LocationToEast != null)
            {
            Console.WriteLine($"[D] Go East");
            }
            Console.WriteLine($"[L] Quest Log");
            Console.WriteLine("[I] Inventory");
            

            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "w":
                    player.Move("north");
                    continue;
                case "a":
                    player.Move("west");
                    continue;
                case "d":
                    player.Move("east");
                    continue;
                case "s":
                    player.Move("south");
                    continue;
                case "l":
                    player.CurrentLocation.ShowQuests();
                    player.PickQuest();
                    continue;
                case "i":
                    int itemToBeEquipped = player.GetInventory() ?? -1;
                    Print.Dialog(player.EquipInventoryItem(itemToBeEquipped), color: ConsoleColor.Green);
                    continue;
                default:
                    continue;
            }
        }

    }
}