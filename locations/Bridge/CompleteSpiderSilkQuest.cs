namespace Project_Alpha_Teem.locations.Bridge;

public class CompleteSpiderSilkQuest : QuestLine
{
    public override void QuestLogic()
    {
        Console.Clear();
        Print.Dialog("You return to the village square where Grissom is anxiously pacing around his candy cart.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'You're back! And in one piece too! Did ya get my silk?'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("You hand over the three bundles of spider silk. Grissom's eyes widen with delight.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'BY THE SUGAR FAIRIES! This is perfect! Look at the quality!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect, Print.ColorMode.Gradient);
        Thread.Sleep(500);
        
        Print.Dialog("He holds one bundle up to the light, squinting at it with surprising expertise.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'And you even got some from the queen! This'll make the BEST batch of candy I've made in years!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Grissom fumbles through his pockets, pulling out various candies, trinkets, and what appears to be a pet rock before finding a small pouch.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("'Here's your reward, as promised! And a special treat - my Spider Silk Candy! Heals ya right up in a pinch, it does!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        // Comment: Give quest rewards to player (experience, gold, and special candy item)
        World.Player.ReceiveQuestRewards(150, 75);
        // Comment: Add special healing candy item to inventory
        // World.Player.AddItemToInventory(new HealingItem("Spider Cotton Candy", "A sweet treat that heals 50 HP when used in battle.", 50));
        
        Print.Dialog("You gained 150 experience and 75 gold!",
            ConsoleColor.Green, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("Special item added: Spider Cotton Candy (Heals 50 HP when used in battle)",
            ConsoleColor.Magenta, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Grissom immediately gets to work with his silk, humming happily to himself.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'Come back anytime for more candy! And if ya see any more big spiders out there, you know where to find me!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Console.Clear();
        Print.Dialog("Quest Complete: Collect Spider Silk", 
            ConsoleColor.Green, Print.PrintStyle.TypeEffect, Print.ColorMode.Gradient);
        Thread.Sleep(1000);
        
        
    }
}