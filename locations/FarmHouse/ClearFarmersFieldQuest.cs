namespace Project_Alpha_Teem.locations.AlchemistsGarden;

public class ClearFarmersFieldQuest : QuestLine
{
    public List<Monster> snakes;

    public override void QuestLogic()
    {
        // Implementeer hier de quest logica, dit kunnen trackers, acties, dialogen, puzzels, etc. zijn.
        // Als een quest verwacht dat je naar een andere area gaat en daar iets doet, maak dan een nieuwe questline aan voor die area met de verwachte acties.
        Print.Dialog("Snakes have been attacking farmers in the field. To clear the quest kill 3 snakes");
        for (int i = 0; i < 3; i++)
        {
            snakes.Add(World.MonsterByID(2));
        }

        Player player = World.Player;

        foreach (Monster snake in snakes)
        {
            Battle battle = new Battle(player, snake);
            battle.Turn()
            Thread.Sleep(2000);
            Console.Clear()
        }
        Print.Dialog("You have cleared the Alchemist's Garden of all the spiders. The people of the town are grateful for your help.");
        Thread.Sleep(1000);
    }
}