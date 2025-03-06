public static class Shop
{
    private static List<Weapon> WeaponsForSale = new List<Weapon>();

    public Shop()
    {
        //add items
        //WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_SWORD_OF_SPIDER_SLAYING));
        WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_CLUB));
    }
    
    public static void VisitShop(Player player)
    {
        Console.WriteLine("Welcome to the shop.");
        bool shopping = true;

        while (shopping)
        {
            Console.WriteLine("[1] Look at wares");
            Console.WriteLine("[2] Talk to shopkeep");
            Console.WriteLine("[3] Leave shop");
            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    DisplayItems(player);
                    continue;
                case "2":
                    continue;
                case "3":
                    shopping = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    continue;
            }
            
        }
    }

    public static void DisplayItems(Player player);
    {
        Console.WriteLine("Items available for purchase: ");
        for (int i = 0; i < WeaponsForSale.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {weapon.Name} - {weapon.Price} gold."); //add gold to weapon class
        }
        Console.WriteLine();
        do
        {
            Console.WriteLine("Would you like to buy something? (y/n)");
            string action = Console.ReadLine().ToLower();
        } while ( action != "y" && action != "n");

        if (action == "y")
        {
            Console.WriteLine("What would you like to buy?");
            string item = Console.ReadLine();
            PurchaseItem(player, item - 1);
        }
        
    }

    public static void PurchaseItem(Player player, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= WeaponForSale.Count)
        {
            Console.WriteLine("Invalid item.")
            return;
        }
        
        Weapon weapon = WeaponsForSale[itemIndex];
        if (player.Money >= weapon.Price)
        {
            player.Money -= weapon.Price;
            player.CurrentWeapon = weapon;
            Console.WriteLine($"You purchased {weapon.Name}.");
        }
        else
        {
            Console.WriteLine("You do not have enough gold.");
        }
    }
}