namespace Project_Alpha_Teem.locations.AlchemistsGarden;

public class ClearFarmersFieldQuest : QuestLine
{
    public List<Monster> snakes = [];

    public override void QuestLogic()
    {
        // Implementeer hier de quest logica, dit kunnen trackers, acties, dialogen, puzzels, etc. zijn.
        // Als een quest verwacht dat je naar een andere area gaat en daar iets doet, maak dan een nieuwe questline aan voor die area met de verwachte acties.
        Print.Dialog("Snakes have been attacking farmers in the field. To clear the quest kill 3 snakes");
        Monster temp = World.MonsterByID(2);

        for (int i = 0; i < 3; i++)
        {
            Monster snake = new Monster(temp.ID, temp.Name, temp.BaseDamage, temp.CurrentHitPoints, temp.critChance);
            snakes.Add(snake);
        }

        Player player = World.Player;
        player.CurrentLocation = World.LocationByID(7);
        player.Alive = true;

        foreach (Monster snake in snakes)
        {
            if (player.CurrentLocation == World.LocationByID(7))
            {
                Battle battle = new Battle(player, snake);
                while (battle.Active)
                {
                    battle.Turn();
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        if (player.Alive)
        {
            Print.Dialog("You have cleared the Farmers Field of all the snakes. The farmers of the town are grateful for your help.",
                style: Print.PrintStyle.TypeEffect,
                color: ConsoleColor.Yellow,
                typeSpeed: 100);
            World.Player.ReceiveQuestRewards(100, 50);
            Thread.Sleep(1000);
        }
    }
}