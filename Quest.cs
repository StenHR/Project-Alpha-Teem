using Project_Alpha_Teem;

public class Quest
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public QuestLine QuestLine { get; set; }

    public Quest(int id, string name, string description, QuestLine questline)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestLine = questline;
    }
}