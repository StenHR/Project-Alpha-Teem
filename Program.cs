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
                Console.WriteLine("Please enter a name...");
            }
        }
        while (string.IsNullOrWhiteSpace(name));

        Location startLocation = World.LocationByID(World.LOCATION_ID_HOME);
        Player player = new(name, startLocation);
        player.CurrentWeapon = World.Weapons[0];

        Print.Dialog($"Hello there {player.Name}!");
        Print.Dialog("Here's thy deal... The people in town are being terrorized by giant spiders.\n" +
            "You decide to do what you can to help. \n\r\nObjective: complete all quests");

    }
}