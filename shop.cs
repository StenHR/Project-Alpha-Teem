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
                    SellItem(player);
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
            player.AddInventoryItem(weapon);
            Console.WriteLine($"You purchased {weapon.Name}.");
        }
        else
        {
            Console.WriteLine("You do not have enough gold.");
        }
    }

    public static void SellItem(Player player)
    {
        bool sell = true;

        while (sell)
        {
            Print.Dialog("What item would you like to sell?", style: Print.PrintStyle.TypeEffect);
            player.GetInventory();
            Console.WriteLine("[0] Cancel");
            Console.Write("Enter number: ");

            if (!int.TryParse(Console.ReadLine(), out int itemSell))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (itemSell == 0)
            {
                break;
            }

            Item item = player.inventory.Find(i => i.ID == itemSell);

            if (item == null)
            {
                Console.WriteLine("Item not found. Please try again.");
                continue;
            }

            player.Money += item.Gold + 10;
            player.inventory.Remove(item);
            Console.WriteLine($"You sold {item.Name} for {item.Gold + 10} gold!");

            Console.Write("Do you want to sell another item? (y/n): ");
            string response = Console.ReadLine().Trim().ToLower();
            if (response != "y")
            {
                sell = false;
            }
        }
    }
}