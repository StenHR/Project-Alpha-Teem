public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int Gold;

    public Weapon(int id, string name, int maximumDamage, int gold)
    {
        this.ID = id;
        this.Name = name;
        this.MaximumDamage = maximumDamage;
        this.Gold = gold;
    }
}