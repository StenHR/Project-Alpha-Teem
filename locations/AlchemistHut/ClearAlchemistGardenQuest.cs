﻿namespace Project_Alpha_Teem.locations.AlchemistsGarden;

public class ClearAlchemistGardenQuest: QuestLine
{

    public List<Monster> Enemies = new List<Monster>();
    public Monster rat = World.MonsterByID(1);

    public ClearAlchemistGardenQuest()
    {
        for (int i = 0; i <= 3; i++)
        {
            this.Enemies.Add(new Monster(rat.ID, rat.Name, rat.BaseDamage, rat.CurrentHitPoints, rat.critChance));
        }
    }
       
    public override void QuestLogic()
    {

        string startQuest;

        do
        {
            Print.Dialog($"You are in the {World.Player.CurrentLocation.Name} and you see the rats. Clear them out? [y/n]", style: Print.PrintStyle.TypeEffect);
            startQuest = Console.ReadLine().ToLower();
        } while (string.IsNullOrEmpty(startQuest) && startQuest != "y" && startQuest != "n");

        if (startQuest == "n")
        {
            return;
        }

        foreach (Monster rat in this.Enemies)
        {
            Battle battle = new Battle(player: World.Player, monster: rat);
            while (battle.Active)
            {
                battle.Turn();
            }

            Console.WriteLine("\n");
            Thread.Sleep(1000);
        }

        //// Implementeer hier de quest logica, dit kunnen trackers, acties, dialogen, puzzels, etc. zijn.
        //// Als een quest verwacht dat je naar een andere area gaat en daar iets doet, maak dan een nieuwe questline aan voor die area met de verwachte acties.
        Print.Dialog("You have cleared the Alchemist's Garden of all the spiders. The people of the town are grateful for your help.",
            style: Print.PrintStyle.TypeEffect, color: ConsoleColor.Green);

        Print.Dialog($"You are awarded {World.QuestByID(1).MoneyReward} coin(s), and {World.QuestByID(1).ExperienceReward} XP!",
    style: Print.PrintStyle.TypeEffect, color: ConsoleColor.Green);

        World.Player.ReceiveQuestRewards(World.QuestByID(1).MoneyReward, World.QuestByID(1).ExperienceReward);
        World.Player.CurrentQuest = null;
        Thread.Sleep(1000);

    }
}