using Project_Alpha_Teem;

public class Quest
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public QuestLine QuestLine { get; set; }
    public int MoneyReward { get; set; }
    public int ExperienceReward { get; set; }
    public bool IsAvailable { get; set; }

    public Quest(int id, string name, string description, QuestLine questLine, bool isAvailable = true, int moneyReward = 0, int experienceReward = 0)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestLine = questLine;
        MoneyReward = moneyReward;
        ExperienceReward = experienceReward;
        IsAvailable = isAvailable;
    }
    
    public void IsCompleted()
    {
        IsAvailable = false;
    }
}