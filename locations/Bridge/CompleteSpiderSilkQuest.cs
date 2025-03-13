namespace Project_Alpha_Teem.locations.Bridge;

public class CompleteSpiderSilkQuest : QuestLine
{
    public override void QuestLogic()
    {
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("'You're back! And in one piece too! Did ya get my silk?'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You hand over the three bundles of spider silk.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Rainbow);
        
        Print.Dialog("'BY THE SUGAR FAIRIES! This is perfect! Look at the quality!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect, Print.ColorMode.Gradient);
        Thread.Sleep(500);
        
        Print.Dialog("He holds one bundle up to the light, examining it with surprising expertise.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'And you even got some from the queen! This'll make the BEST batch of candy I've made in years!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Here's your reward! And a special treat - my Spider Silk Candy! Heals ya right up in a pinch!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        
        // Give quest rewards to player
        Print.Dialog(World.Player.ReceiveQuestRewards(150, 75),
        ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);

        // Add special healing candy item to inventory
        // World.Player.AddItemToInventory(new HealingItem("Spider Cotton Candy", "A sweet treat that heals 50 HP when used in battle.", 50));
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You gained 150 experience and 75 gold!",
            ConsoleColor.Green, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("Special item added: Spider Cotton Candy (Heals 50 HP when used in battle)",
            ConsoleColor.Magenta, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("'Come back anytime for more candy! And if ya see any more big spiders out there, you know where to find me!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Console.Clear();
        Print.Dialog("Quest Complete: Collect Spider Silk", 
            ConsoleColor.Green, Print.PrintStyle.TypeEffect, Print.ColorMode.Rainbow);
        Thread.Sleep(1000);
        
        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_COMPLETE_SPIDER_SILK).IsAvailable = false;
    }
}