public class Monster
{
    int ID;
    string Name;
    int BaseDamage;
    int CurrentHitPoints;
    double critChance;

    public Monster(int id, string name, int basedmg = 20, int currenthp = 100, double critChance) {
        this.ID = id;
        this.BaseDamage = basedmg;
        this.Name = name;
        this.CurrentHitPoints = currenthp;
    }

    public int CalculateDamage()
    {
        Random rng = new Random();
        if (rng.NextDouble() < critChance)
        {
            return BaseDamage * rng.NextDouble() + 1;
        }
        return BaseDamage;
    }
}
