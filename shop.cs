public static class Shop
{
    private static List<Weapon> WeaponsForSale = new List<Weapon>();

    static Shop()
    {
        // Add items
        WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_SWORD_OF_SPIDER_SLAYING));
        WeaponsForSale.Add(World.WeaponByID(World.WEAPON_ID_CLUB));
    }

    // Logic when player is in the store
    public static void VisitShop(Player player)
    {
        bool shopping = true;
        while (shopping)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the shop.");
            Print.Dialog("[1] Look at wares", ConsoleColor.Cyan);
            Print.Dialog("[2] Sell item", ConsoleColor.Cyan);
            Print.Dialog("[3] Talk to shopkeep", ConsoleColor.Cyan);
            Print.Dialog("[4] Leave shop", ConsoleColor.Cyan);
            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    Console.Clear();
                    DisplayItems(player);
                    continue;
                case "2":
                    Console.Clear();
                    SellItem(player);
                    continue;
                case "3":
                    Console.Clear();
                    Console.WriteLine("The shopkeeper greets you warmly.");
                    Thread.Sleep(2000);
                    continue;
                case "4":
                    shopping = false;
                    break;
                default:
                    Console.Clear();
                    Print.Dialog("Invalid option.", ConsoleColor.Red);
                    Thread.Sleep(2000);
                    continue;
            }
        }
    }

    private static void DisplayItems(Player player)
    {
        Print.Dialog("Items available for purchase:", ConsoleColor.Cyan);

        if (WeaponsForSale.Count == 0)
        {
            Print.Dialog("Sold out!\n", color: ConsoleColor.Red);
            return;
        }

        for (int i = 0; i < WeaponsForSale.Count; i++)
        {
            Weapon weapon = WeaponsForSale[i];
            Print.Dialog($"{i + 1}. {weapon.Name} - {weapon.Gold} gold", ConsoleColor.Yellow);
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
                Print.Dialog("Invalid selection.", ConsoleColor.Red);
            }
        }
    }

    private static void PurchaseItem(Player player, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= WeaponsForSale.Count)
        {
            Print.Dialog("Invalid item selection.", ConsoleColor.Red);
            return;
        }

        Weapon weapon = WeaponsForSale[itemIndex];
        if (player.Money >= weapon.Gold)
        {
            WeaponsForSale.Remove(weapon);
            player.Money -= weapon.Gold;
            player.AddInventoryItem(weapon);
            Console.WriteLine($"You purchased {weapon.Name}.");
        }
        else
        {
            Print.Dialog("You do not have enough gold.", ConsoleColor.Red);
        }
    }

    public static void SellItem(Player player)
    {
            Print.Dialog("Your inventory: ", ConsoleColor.Yellow);
        
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Item item = player.Inventory[i];
            Console.WriteLine($"{i + 1}. {item.Name} - {item.Gold} gold");
        }
        Console.WriteLine();

        Console.WriteLine("Enter the number of the item you want to sell, or '0' to cancel:");
        string itemInput = Console.ReadLine();
        if (int.TryParse(itemInput, out int itemNumber) && itemNumber > 0 && itemNumber <= player.Inventory.Count)
        {
            Item itemToSell = player.Inventory[itemNumber - 1];
            player.Money += itemToSell.Gold;
            player.Inventory.Remove(itemToSell);
            WeaponsForSale.Add((Weapon)itemToSell);
            Console.WriteLine();
            Print.Dialog($"You sold {itemToSell.Name} for {itemToSell.Gold} gold!", ConsoleColor.Yellow);
            Thread.Sleep(2000);
        }
        else if (itemNumber == 0)
        {
            Print.Dialog("Sell Cancelled.", ConsoleColor.Red);
            Thread.Sleep(2000);
        }
        else
        {
            Print.Dialog("Invalid selection.", ConsoleColor.Red);
            Thread.Sleep(2000);
        }
    }
}