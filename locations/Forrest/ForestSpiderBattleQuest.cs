namespace Project_Alpha_Teem.locations.Forrest;

public class ForestSpiderBattleQuest : QuestLine
{
    public override void QuestLogic()
    {
        Console.Clear();
        Print.Dialog("You arrive at the forest west of the bridge. The trees grow close together, and silken strands hang between branches.",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("As you venture deeper, you notice intricate webs spanning between the trees.",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("The webs shimmer with an almost magical quality in the dappled sunlight filtering through the canopy.",
            ConsoleColor.DarkGreen, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("You hear a soft chittering sound from the shadows of the forest...",
            ConsoleColor.DarkCyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        // First spider battle
        Console.Clear();
        Print.Dialog("Suddenly, a spider about the size of a dinner plate skitters down a tree trunk!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        // Comment: Create first spider monster
        // Monster spider1 = new Monster(id, "Small Silkfang Spider", damage, hitPoints, critChance);
        // Comment: Battle logic here
        
        Console.Clear();
        Print.Dialog("You carefully collect a bundle of silk from the defeated spider.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("One down, two more to go...",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(400);
        
        // Second spider battle
        Console.Clear();
        Print.Dialog("As you move deeper into the forest, you disturb another spider hiding in the undergrowth!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        // Comment: Create second spider monster
        // Monster spider2 = new Monster(id, "Silkfang Spider", damage, hitPoints, critChance);
        // Comment: Battle logic here
        
        Console.Clear();
        Print.Dialog("You gather another bundle of silk, noticing that it shimmers with a subtle blue tint.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("Just one more bundle needed...",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(400);
        
        // Final spider battle
        Console.Clear();
        Print.Dialog("In a small clearing, you spot a much larger spider hanging in the center of an enormous web!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(600);
        
        Print.Dialog("This must be the queen of the Silkfang spiders that Grissom mentioned!",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        Print.Dialog("It notices your presence and drops down, fangs glistening with venom!",
            ConsoleColor.Red, Print.PrintStyle.TypeEffect);
        Thread.Sleep(500);
        
        // Comment: Create boss spider monster
        // Monster spider3 = new Monster(id, "Silkfang Queen", damage, hitPoints, critChance);
        // Comment: Battle logic here
        
        Console.Clear();
        Print.Dialog("After a tough battle, you've defeated the Silkfang Queen! Its silk appears to be of the highest quality.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        Print.Dialog("You carefully collect the final bundle of silk. With three bundles safely stored, you head back to find Grissom.",
            ConsoleColor.Cyan, Print.PrintStyle.TypeEffect);
        Thread.Sleep(700);
        
        // Comment: Transition to completion quest
    }
}