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

    public int CalculateDamage()
    {
        Random rng = new Random();
        if (rng.NextDouble() < critChance)
        {
            return Convert.ToInt32(BaseDamage * (rng.NextDouble() + 1));
        }
        return Convert.ToInt32(BaseDamage);
    }

    public string GetMonsterStats() => $"| Name: {this.Name}; Health: {this.CurrentHitPoints}";
}
