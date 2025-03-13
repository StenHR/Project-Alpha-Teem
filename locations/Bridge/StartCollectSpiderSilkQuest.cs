namespace Project_Alpha_Teem.locations.Bridge;

public class StartCollectSpiderSilkQuest : QuestLine
{
    public override void QuestLogic()
    {
        Console.Clear();
        
        // Introduction to the old candy seller
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("'COTTON SPIDER CANDY! GET YER COTTON SPIDER CANDY!'", 
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect, Print.ColorMode.Blinking);
        Thread.Sleep(700);
        
        Print.Dialog("The old man notices you and breaks into a toothless grin.", 
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'Well hello there! Name's Grissom! Care for a taste of my special treat?'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You try the candy. It melts in your mouth with a strange yet pleasant texture.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("'Delicious, ain't it? Secret's in the REAL spider silk!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'Oh no! I'm all out of silk! And my bones ain't what they used to be...'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Could you fetch me some spider silk from the forest west of the bridge? The Silkfang spiders there make the BEST silk!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        string startQuest;
        do
        {
            Console.Clear();
            Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
                ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
            Print.Dialog("Will you collect some spider silk for the old man? [y/n]", 
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
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("OldMan"), 
            ConsoleColor.DarkYellow, Print.PrintStyle.Instant, Print.ColorMode.Gradient);
        
        Print.Dialog("'WONDERFUL! I need three bundles of silk. But watch yourself - those spiders can be nasty!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Just give 'em a good whack if they get too friendly! And DON'T squish 'em completely!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        
        Console.Clear();
        Print.Dialog(AsciiArtGallery.DisplayArt("Player"), 
            ConsoleColor.Blue, Print.PrintStyle.Instant);
        
        Print.Dialog("You set off toward the forest west of the bridge.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Good luck! And don't get eaten!' Grissom calls after you with a cheerful wave.",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        
        Print.Dialog(World.Player.ReceiveQuestRewards(150, 75),
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);

        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_BATTLE_SPIDERS).IsAvailable = true;
        World.Quests.FirstOrDefault(q => q.ID == World.QUEST_ID_START_SPIDER_SILK).IsAvailable = false;
    }
}