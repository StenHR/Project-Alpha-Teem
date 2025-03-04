public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public List<Quest> QuestAvailableHere = new();
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;

    public Location(int id, string name, string description, 
                List<Quest> questAvailableHere, Monster monsterLivingHere = null)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = questAvailableHere ?? new List<Quest>(); ;
        this.MonsterLivingHere = monsterLivingHere;
    }
    
    public void ShowQuests()
    {
        Print.Dialog("The following quests are available:\n");

        foreach (var quest in QuestAvailableHere)
        {
            Print.Dialog(new string('=', 20));
            Print.Dialog($"Quest number   : {quest.ID}");
            Print.Dialog($"Name       : {quest.Name}");
            Print.Dialog($"Description: {quest.Description}");
            Print.Dialog(new string('=', 20));
        }
    }

    public string ShowDescription()
    {
        return Description;
    }
    
    public Quest PickQuest()
    {
        Print.Dialog("Please enter the number of the quest you would like to take:");
        int questNumber;
        Print.Dialog(">> ");
    
        while (!int.TryParse(Console.ReadLine(), out questNumber))
        {
            Print.Dialog("Invalid input. Please enter a valid quest number:");
            Print.Dialog(">> ");
        }
    
        return QuestAvailableHere.FirstOrDefault(q => q.ID == questNumber);
    }
}
