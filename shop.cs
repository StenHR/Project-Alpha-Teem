public static class Shop
{
    private static List<Weapon> WeaponsForSale = new List<Weapon>();

    static Shop()
    {
        // Add items
        WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_SWORD_OF_SPIDER_SLAYING));
        WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_CLUB));
    }

    public static void VisitShop(Player player)
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the shop.");
        bool shopping = true;

        while (shopping)
        {
            Console.WriteLine("[1] Look at wares");
            Console.WriteLine("[2] Sell item");
            Console.WriteLine("[3] Talk to shopkeep");
            Console.WriteLine("[4] Leave shop");
            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    DisplayItems(player);
                    continue;
                case "2":
                    // SellItem(player); // Implement this method if needed
                    continue;
                case "3":
                    Console.WriteLine("The shopkeeper greets you warmly.");
                    continue;
                case "4":
                    shopping = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    continue;
            }
        }
    }

    private static void DisplayItems(Player player)
    {
        Console.WriteLine();
        Console.WriteLine("Items available for purchase:");
        for (int i = 0; i < WeaponsForSale.Count; i++)
        {
            Weapon weapon = WeaponsForSale[i];
            Console.WriteLine($"{i + 1}. {weapon.Name} - {weapon.Gold} gold");
        }
        Console.WriteLine();

        string action;
        do
        {
            Console.WriteLine("Would you like to buy something? (y/n)");
            action = Console.ReadLine().ToLower();
        } while (action != "y" && action != "n");

        if (action == "y")
        {
            Console.WriteLine("Enter the number of the item you want to buy:");
            string itemInput = Console.ReadLine();
            if (int.TryParse(itemInput, out int itemNumber) && itemNumber > 0 && itemNumber <= WeaponsForSale.Count)
            {
                PurchaseItem(player, itemNumber - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    private static void PurchaseItem(Player player, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= WeaponsForSale.Count)
        {
            Console.WriteLine("Invalid item selection.");
            return;
        }

        Weapon weapon = WeaponsForSale[itemIndex];
        if (player.Money >= weapon.Gold)
        {
            player.Money -= weapon.Gold;
            player.CurrentWeapon = weapon;
            Console.WriteLine($"You purchased {weapon.Name}.");
        }
        else
        {
            Console.WriteLine("You do not have enough gold.");
        }
    }

    // public static void SellItem(Player player)
    // {
    //     // Implementation for selling items
    // }
}