namespace Project_Alpha_Teem;

public class QuestLine
{
    public void SetQuestline()
    {
        foreach (var Quest in Quest._instances)
        {
            
        }
    }
    
    public void Questline1()
    {
        Print.Dialog("You have been tasked with slaying the dragon terrorizing the village.");
        Print.Dialog("The dragon is said to be living in the cave to the east of the village.");
        Print.Dialog("You must defeat the dragon to complete this quest.");
    }
}