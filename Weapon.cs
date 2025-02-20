public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;

    public Weapon(int id, string name, int maximumDamage)
    {
        this.ID = id;
        this.Name = name;
        this.MaximumDamage = maximumDamage;
    }
}