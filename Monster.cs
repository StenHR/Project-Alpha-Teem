public class Monster
{
    public int ID;
    public string Name;
    public double BaseDamage;
    public int CurrentHitPoints;
    public double critChance;

    public Monster(int id, string name, double basedmg = 20.0, int currenthp = 100, double critChance = 0.25) {
        this.ID = id;
        this.BaseDamage = basedmg;
        this.Name = name;
        this.CurrentHitPoints = currenthp;
    }

    public double CalculateDamage()
    {
        Random rng = new Random();
        if (rng.NextDouble() < critChance)
        {
            return BaseDamage * rng.NextDouble() + 1;
        }
        return BaseDamage;
    }
}
