using Project_Alpha_Teem;

public class Quest
{
    public static List<Quest> _instances = new ();

    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public questline { get; set; }

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        _instances.Add(this);
    }
    
    public void SetQuestline(questline)
    {
        this.questline = questline;
    }
    
    public void StartQuestline()
    {

    }
}