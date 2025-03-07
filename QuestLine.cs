namespace Project_Alpha_Teem;

public abstract class QuestLine
{
    public abstract void QuestLogic();
    
    public void RunQuest()
    {
        QuestLogic();
    }
}