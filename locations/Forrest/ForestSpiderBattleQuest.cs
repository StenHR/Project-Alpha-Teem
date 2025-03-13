namespace Project_Alpha_Teem.locations.Forrest;

public class ForestSpiderBattleQuest : QuestLine
{
    public List<Monster> ForestSpiders = new();
    
    public ForestSpiderBattleQuest()
    {
        // Create three spiders with progressively increasing difficulty
        // Based on Queen stats (8 damage, 40 HP, 15 crit) but scaled down
        ForestSpiders.Add(new Monster(3, "Silkfang Lurker", 4, 20, 10));
        ForestSpiders.Add(new Monster(3, "Silkfang Hunter", 5, 25, 12));
        ForestSpiders.Add(new Monster(3, "Elder Silkfang", 7, 35, 15));
    }
    
    public override void QuestLogic()
    {
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Web"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant, Print.ColorMode.Rainbow);
        
        Print.Dialog("The old bridge creaks beneath your feet as you cross into the western forest.",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Grissom's words echo in your mind as you spot the glistening webs between the ancient trees.",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Cyan, Print.PrintStyle.Instant);
        
        Print.Dialog("The forest is eerily quiet except for the occasional rustling in the canopy above.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        string startQuest;
        do
        {
            Console.Clear();
            Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
                ConsoleColor.Cyan, Print.PrintStyle.Instant);
            Print.Dialog("Do you want to venture deeper to collect the silk Grissom needs? [y/n]", 
                ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
            startQuest = Console.ReadLine().ToLower();
        } while (string.IsNullOrEmpty(startQuest) && startQuest != "y" && startQuest != "n");

        if (startQuest == "n")
        {
            Console.Clear();
            Print.Dialog("You decide the risk isn't worth it. Grissom will have to find silk elsewhere.", 
                ConsoleColor.Gray, Print.PrintStyle.TypeEffect);
            Thread.Sleep(1000);
            return;
        }

        // First spider encounter
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Spider"), 
            ConsoleColor.Green, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog($"A {ForestSpiders[0].Name} descends on a silken thread directly in front of you!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("Its eight eyes study you intently as it prepares to attack!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Battle firstBattle = new Battle(player: World.Player, monster: ForestSpiders[0]);
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
            ConsoleColor.Cyan, Print.PrintStyle.Instant);
        
        Print.Dialog("You've defeated the Silkfang Lurker and harvest a small amount of silk.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        Print.Dialog("The silk is thin but remarkably strong. One bundle collected, two to go.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        // Second spider encounter
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Web"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant, Print.ColorMode.Blinking);
        
        Print.Dialog("As you press on, the web density increases. You accidentally brush against a strand...",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Spider-2"), 
            ConsoleColor.Yellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog($"The vibration alerts a {ForestSpiders[1].Name} that rushes out from behind a hollow tree!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("This one is larger, with distinctive yellow markings on its back!",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Battle secondBattle = new Battle(player: World.Player, monster: ForestSpiders[1]);
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
            ConsoleColor.Cyan, Print.PrintStyle.Instant);
        
        Print.Dialog("The Hunter falls, and you extract another bundle of silk from its spinnerets.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("This silk has a golden hue and seems even stronger than the first bundle.",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        // Third spider encounter
        Console.Clear();
        Print.Dialog("The forest becomes darker as the canopy thickens. The air feels heavy with moisture.",
            ConsoleColor.DarkCyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        Print.Dialog("You enter a small grotto where the sunlight filters through in ghostly beams.",
            ConsoleColor.DarkCyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Spider-3"), 
            ConsoleColor.Magenta, Print.PrintStyle.Instant, Print.ColorMode.Random);
        
        Print.Dialog($"From the shadows emerges an {ForestSpiders[2].Name}, its legs making a chittering sound on the bark!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Its body is scared from countless battles, and its fangs glisten with venom.",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Battle thirdBattle = new Battle(player: World.Player, monster: ForestSpiders[2]);
        while (thirdBattle.Active)
        {
            thirdBattle.BattleMenu();
        }

        if (thirdBattle.PlayerDied())
        {
            return;
        }
        
        Thread.Sleep(1000);
        Console.Clear();
        
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Cyan, Print.PrintStyle.Instant);
        
        Print.Dialog("With a final strike, you defeat the Elder Silkfang. Its silk is the most pristine you've seen.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("The final bundle has a subtle purple sheen and feels impossibly light yet strong.",
            ConsoleColor.Magenta, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Console.Clear();
        Print.Dialog("You've collected all three bundles of spider silk for Grissom!", 
            ConsoleColor.Green, Print.PrintStyle.TypeEffect, Print.ColorMode.Rainbow);
        Thread.Sleep(600);
        
        Print.Dialog("The forest seems to relax around you as you make your way back to the bridge.", 
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("You've collected all the silk needed for Grissom's candy!", 
            ConsoleColor.Green, Print.PrintStyle.TypeEffect, Print.ColorMode.Rainbow);
        Thread.Sleep(600);
        
        Print.Dialog(World.Player.ReceiveQuestRewards(150, 75),
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        
        // Update quest availability
        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_COMPLETE_SPIDER_SILK).IsAvailable = true;
        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_BATTLE_SPIDERS).IsAvailable = false;
        
        Thread.Sleep(1000);
    }
}
