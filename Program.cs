class Program
{
    public static void Main()
    {
        Dialog("Hello, world");
    }
    
    public static void Dialog(string dialog)
    {
        foreach (var i in dialog)
        {
            Console.Write(i);
            Thread.Sleep(70);
        }
        Console.WriteLine();
    }
}