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
        this.QuestAvailableHere = questAvailableHere ?? new List<Quest>();
        this.MonsterLivingHere = monsterLivingHere;
    }
    
    public void ShowQuests()
    {
        Console.Clear();
        Print.Dialog($"QUESTS IN {Name.ToUpper()}", 
            ConsoleColor.Yellow, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Single);
            
        Print.Dialog(new string('=', 50), 
            ConsoleColor.DarkGray);
        
        if (QuestAvailableHere?.Any() != true)
        {
            Print.Dialog("There are no quests available here.", 
                ConsoleColor.Red, 
                Print.PrintStyle.TypeEffect);
            return;
        }
        
        foreach (var quest in QuestAvailableHere)
        {
            Print.Dialog($"QUEST #{quest.ID}: {quest.Name}", 
                ConsoleColor.Green, 
                Print.PrintStyle.TypeEffect, 
                Print.ColorMode.Single);
                
            Print.Dialog(quest.Description, 
                ConsoleColor.White, 
                Print.PrintStyle.TypeEffect, 
                typeSpeed: 30);
            Print.Dialog($"Reward(s): {quest.MoneyReward} coin(s), {quest.ExperienceReward} XP", color: ConsoleColor.Green);
            Print.Dialog(new string('-', 40), 
                ConsoleColor.DarkGray);
        }
    }
    
    public Quest PickQuest()
    {
        if (QuestAvailableHere?.Any() != true)
        {
            return null;
        }
        
        Print.Dialog("Enter the number of the quest you want to take:", 
            ConsoleColor.Cyan, 
            Print.PrintStyle.TypeEffect, 
            addNewLine: false);
            
        string input = Console.ReadLine();
        
        if (!int.TryParse(input, out int questNumber))
        {
            Print.Dialog("Invalid input. Returning to game...", 
                ConsoleColor.Red, 
                Print.PrintStyle.TypeEffect);
            Thread.Sleep(1500);
            return null;
        }
        
        Quest selectedQuest = QuestAvailableHere.FirstOrDefault(q => q.ID == questNumber);
        
        if (selectedQuest == null)
        {
            Print.Dialog("Quest not found. Returning to game...", 
                ConsoleColor.Red, 
                Print.PrintStyle.TypeEffect);
            Thread.Sleep(1500);
            return null;
        }
        Console.Clear();
        Print.Dialog($"You have chosen to undertake: {selectedQuest.Name}", 
            ConsoleColor.Green, 
            Print.PrintStyle.TypeEffect, 
            Print.ColorMode.Rainbow);
            
        Thread.Sleep(1500);
        Console.Clear();
        return selectedQuest;
    }

    public string ShowDescription()
    {
        return Description;
    }
}
