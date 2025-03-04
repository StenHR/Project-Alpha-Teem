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
            Dialog("Welcome, player! What is thy name? ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a name...");
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];

        Dialog($"Hello there {player.Name}!");
        Dialog("Here's thy deal... The people in town are being terrorized by giant spiders.\n" +
            "You decide to do what you can to help. \n\r\nObjective: complete all quests");

        var x = true;
        while (x)
        {
            Console.WriteLine("[1] Go North");
            Console.WriteLine("[2] Go West");
            Console.WriteLine("[3] Go East");
            Console.WriteLine("[4] Go South");
            Console.WriteLine("[5] Description");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                    player.Move("north");
                    continue;
                case "2":
                    player.Move("west");
                    continue;
                case "3":
                    player.Move("east");
                    continue;
                case "4":
                    player.Move("south");
                    continue;
                case "5":
                    Console.WriteLine(startLocation.Description);
                    continue;
                default:
                    continue;


            }
        }

    }
    
    public static void Dialog(string dialog)
    {
        foreach (var i in dialog)
        {
            Console.Write(i);
            Thread.Sleep(60);
        }
        Console.WriteLine();
    }
}