public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public List<Quest> QuestAvailableHere;
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
        this.QuestAvailableHere = questAvailableHere;
        this.MonsterLivingHere = monsterLivingHere;
    }
    
    public void ShowQuests(IEnumerable<Quest> quests)
    {
        Program.Dialog("The following quests are available:\n");

        foreach (var quest in quests)
        {
            Program.Dialog(new string('=', 20));
            Program.Dialog($"Quest number   : {quest.ID}");
            Program.Dialog($"Name       : {quest.Name}");
            Program.Dialog($"Description: {quest.Description}");
            Program.Dialog(new string('=', 20));
        }
    }
    
    public Quest PickQuest()
    {
        Program.Dialog("Please enter the number of the quest you would like to take:");
        int questNumber;
        Program.Dialog(">> ");
    
        while (!int.TryParse(Console.ReadLine(), out questNumber))
        {
            Program.Dialog("Invalid input. Please enter a valid quest number:");
            Program.Dialog(">> ");
        }
    
        return QuestAvailableHere.FirstOrDefault(q => q.ID == questNumber);
    }
}
