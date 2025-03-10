public class Weapon : Item
{
    public int MaximumDamage;
    public double critChance;
    public bool IsEquipped;

    public Weapon(int id, string name, int maximumDamage, double cc, int gold)
        : base (id, name, gold)
    {
        MaximumDamage = maximumDamage;
        critChance = cc;
        IsEquipped = false;
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