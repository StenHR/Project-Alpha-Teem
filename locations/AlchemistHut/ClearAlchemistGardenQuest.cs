namespace Project_Alpha_Teem.locations.AlchemistsGarden;

public class ClearAlchemistGardenQuest: QuestLine
{
    public override void QuestLogic()
    {
        // Implementeer hier de quest logica, dit kunnen trackers, acties, dialogen, puzzels, etc. zijn.
        // Als een quest verwacht dat je naar een andere area gaat en daar iets doet, maak dan een nieuwe questline aan voor die area met de verwachte acties.
        Print.Dialog("You have cleared the Alchemist's Garden of all the spiders. The people of the town are grateful for your help.");
        Thread.Sleep(1000);
    }
}