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
        Player player = new("Sten", startLocation);
        player.CurrentWeapon = World.Weapons[0];

        Dialog($"Hello there {player.Name}!");
        Dialog("Here's thy deal... The people in town are being terrorized by giant spiders.\n" +
            "You decide to do what you can to help. \n\r\nObjective: complete all quests");

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