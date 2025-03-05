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
            Print.Dialog($"Reward(s): {quest.MoneyReward} coin(s), {quest.ExperienceReward} XP", color: ConsoleColor.Green);
            Print.Dialog(new string('=', 20));
        }
    }

    public string ShowDescription()
    {
        return Description;
    }
    
}
