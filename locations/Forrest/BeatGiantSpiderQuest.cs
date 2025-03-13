namespace Project_Alpha_Teem.locations.Forrest;

public class BeatGiantSpiderQuest : QuestLine
{
    public List<Monster> Spiders = new();
    public Monster GiantSpider;
    public Monster SpiderQueen;
    
    public BeatGiantSpiderQuest()
    {
        // Create normal spiders
        GiantSpider = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);
        for (int i = 0; i < 2; i++)
        {
            Spiders.Add(new Monster(GiantSpider.ID, GiantSpider.Name, GiantSpider.BaseDamage, GiantSpider.CurrentHitPoints, GiantSpider.critChance));
        }
        
        // Create the boss spider with stronger stats
        SpiderQueen = new Monster(3, "Spider Queen", 8, 40, 15);
    }
    
    public override void QuestLogic()
    {
        Console.Clear();
        
        // Intro dialog
        Print.Dialog(AsciiArtGallery.DisplayArt("Web"), 
            ConsoleColor.Cyan, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("Deep in the forest, you follow a trail of thick webbing...",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);

        Print.Dialog("The path ahead is blocked by massive spider webs. You'll need to clear them to proceed.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        string startQuest;
        do
        {
            Console.Clear();
            Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
                ConsoleColor.Blue, Print.PrintStyle.Instant);
            Print.Dialog("Will you fight through the spiders to defeat the spider queen? [y/n]", 
                ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
            startQuest = Console.ReadLine().ToLower();
        } while (string.IsNullOrEmpty(startQuest) && startQuest != "y" && startQuest != "n");

        if (startQuest == "n")
        {
            Console.Clear();
            Print.Dialog("You decide to turn back. Perhaps another time...", 
                ConsoleColor.Gray, Print.PrintStyle.TypeEffect);
            Thread.Sleep(1000);
            return;
        }

        // First spider battle
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Spider"), 
            ConsoleColor.DarkGray, Print.PrintStyle.Instant, Print.ColorMode.Blinking);
        
        Print.Dialog("A spider drops from the canopy, blocking your path!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Battle firstBattle = new Battle(player: World.Player, monster: Spiders[0]);
        while (firstBattle.Active)
        {
            firstBattle.BattleMenu();
        }
        
        if (firstBattle.PlayerDied())
        {
            return;
        }
        
        Thread.Sleep(1000);
        Console.Clear();
        
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You've defeated the first spider and collect some silk. The path ahead is clearer now.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        // Second spider battle
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Spider-2"), 
            ConsoleColor.DarkMagenta, Print.PrintStyle.Instant, Print.ColorMode.Random);
        
        Print.Dialog("Another spider scuttles from behind a tree, larger than the first!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Battle secondBattle = new Battle(player: World.Player, monster: Spiders[1]);
        while (secondBattle.Active)
        {
            secondBattle.BattleMenu();
        }
        
        if (secondBattle.PlayerDied())
        {
            return;
        }
        
        Thread.Sleep(1000);
        Console.Clear();
        
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You've defeated the second spider and gather more silk. The forest grows quiet...",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Too quiet. You sense something larger awaits ahead.",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(1000);
        
        // Spider Queen battle
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("SpiderBoss"), 
            ConsoleColor.DarkRed, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("The trees open to a clearing dominated by an enormous web. At its center sits a massive spider!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect, Print.ColorMode.Blinking);
        Thread.Sleep(800);
        
        Print.Dialog("The Spider Queen rises on her legs, towering above you. Her fangs drip with venom!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Battle bossBattle = new Battle(player: World.Player, monster: SpiderQueen);
        while (bossBattle.Active)
        {
            bossBattle.BattleMenu();
        }

        if (bossBattle.PlayerDied())
        {
            return;
        }
        
        Thread.Sleep(1000);
        Console.Clear();
        
        // Victory sequence
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You've defeated the Spider Queen! Her silk is of exceptional quality.",
            ConsoleColor.Green, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("You collect her corpse and the remaining silk, after her defeat you feel a sense of peace.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        Console.Clear();
        
        Print.Dialog("You gained 300 experience and 75 gold!", 
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        World.Player.ReceiveQuestRewards(75, 300);
        
        // Make the current quest unavailable
        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_BEAT_GIANT_SPIDER).IsAvailable = false;
        
        Thread.Sleep(1000);
    }
}
