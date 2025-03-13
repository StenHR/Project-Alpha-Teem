namespace Project_Alpha_Teem.locations.Bridge;

public class StartCollectSpiderSilkQuest : QuestLine
{
    public override void QuestLogic()
    {
        Console.Clear();
        
        // Introduction to the old candy seller
        Print.Dialog("As you approach the village square, you notice a peculiar old man with a colorful cart.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'COTTON SPIDER CANDY! GET YER COTTON SPIDER CANDY!'", 
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect, Print.ColorMode.Blinking);
        Thread.Sleep(700);
        
        Print.Dialog("The old man notices you watching him and breaks into a toothless grin.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'Well hello there, youngster! Name's Grissom! Care for a taste of my special treat?'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("He offers you a sample of his candy. It melts in your mouth with a strange yet pleasant texture.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Delicious, ain't it? Secret's in the REAL spider silk! Not that fake stuff other candy makers use!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("Grissom's smile suddenly fades as he rummages through his supplies.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("'Oh no no NO! I'm all out of silk! And my bones ain't what they used to be...'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("He eyes you hopefully, scratching his wild white hair.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(400);
        
        Print.Dialog("'Say, you look like a capable sort! Could you fetch me some spider silk from the forest west of the old bridge? The Silkfang spiders there make the BEST silk for my candy!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(800);
        
        // Comment: Add yes/no choice option here. If "no" is selected, end conversation politely
        
        Console.Clear();
        Print.Dialog("'WONDERFUL! I need three bundles of silk. But watch yourself - those spiders can be nasty!'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Just give 'em a good whack if they get too friendly! And DON'T squish 'em completely! Need the silk glands intact, ya see.'",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("Grissom makes a vague swatting motion that nearly knocks him off balance.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Console.Clear();
        Print.Dialog("You set off toward the forest west of the bridge, leaving Grissom behind with his candy cart.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("'Good luck! And don't get eaten!' Grissom calls after you with a cheerful wave.",
            ConsoleColor.Yellow, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);

        World.Quests.Where(q => q.ID == World.QUEST_ID_BATTLE_SPIDERS).FirstOrDefault().IsAvailable = true;
        // Comment: Transition to forest quest
    }
}