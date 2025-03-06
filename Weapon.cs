public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public double critChance;

    public Weapon(int id, string name, int maximumDamage, double cc)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumDamage;
        critChance = cc;
    }

    public int CalculateDamage()
    {
        Random rng = new Random();

        double BaseDamage = MaximumDamage * rng.Next(80, 120)/100;

        if (rng.NextDouble() < critChance)
        {
            return Convert.ToInt32(BaseDamage * (rng.NextDouble() + 1));
        }
        return Convert.ToInt32(BaseDamage);
    }
}