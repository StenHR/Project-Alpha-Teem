namespace Project_Alpha_Teem.locations.AlchemistsGarden;

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

        Battle battleEnemy1 = new Battle(player: World.Player, this.Enemies[0]);

        while (battleEnemy1.Active)
        {
            battleEnemy1.Turn();
        }

        battleEnemy1.Active = false;

        Battle battleEnemy2 = new Battle(player: World.Player, this.Enemies[1]);

        while (battleEnemy2.Active)
        {
            battleEnemy1.Turn();
        }

        battleEnemy2.Active = false;

        Battle battleEnemy3 = new Battle(player: World.Player, this.Enemies[2]);

        while (battleEnemy3.Active)
        {
            battleEnemy1.Turn();
        }

        battleEnemy3.Active = false;

        //// Implementeer hier de quest logica, dit kunnen trackers, acties, dialogen, puzzels, etc. zijn.
        //// Als een quest verwacht dat je naar een andere area gaat en daar iets doet, maak dan een nieuwe questline aan voor die area met de verwachte acties.
        Print.Dialog("You have cleared the Alchemist's Garden of all the spiders. The people of the town are grateful for your help.",
            style: Print.PrintStyle.TypeEffect);
        World.Player.ReceiveQuestRewards(50, 25);
        World.Player.CurrentQuest = null;
        Thread.Sleep(1000);
    }
}