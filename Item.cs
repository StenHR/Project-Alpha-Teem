public abstract class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Gold { get; set; }

    public Item(int id, string name, int gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}