public class Location
{
    public int ID
    public string Name
    public string Description
    public Quest QuestAvailableHere
    public Monster MonsterLivingHere
    public Location LocationToNorth
    public Location LocationToSouth
    public Location LocationToEast
    public Location LocationToWest

    public Location(int id, string name, string description, 
                Quest questAvailableHere = null, Monster monsterLivingHere = null)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.QuestAvailableHere = questAvailableHere;
        this.MonsterLivingHere = monsterLivingHere;
    }

    public void ShowDescription()
    {
        Console.WriteLine($"{Name}: {Description}");
        if (QuestAvailableHere != null)
        {
            Console.WriteLine($"Quest available: {QuestAvailableHere.Name}");
        }
    }
}