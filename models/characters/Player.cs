using Fantasy1998.models.characters;

namespace Fantasy1998.models.player;
public class Player : GameObject, IAllies
{
    public double Health      { get; set; }
    public double Stamina     { get; set; }
    public double Mana        { get; set; }
    public double MaxHealth   { get; set; }
    public double MaxStamina  { get; set; }
    public double MaxMana     { get; set; }
    public double AP          { get; set; }
    public double AD          { get; set; }
    public double Armor       { get; set; }
    public double MR          { get; set; }
    public double Speed       { get; set; }
    public double XP          { get; set; }
    public double MaxXP       { get; set; }
    public int Level         { get; set; }
    private Random _random = new Random();
    public List<Allies> Team { get; set; } = new List<Allies>();
    public Player(string name, (int row, int col) currentPos) : base(name, currentPos)
    {

    }
    public double CalculateXPBonus(IEnemies enemy)
    {
        double diff = enemy.Level - Team.Average(p => p.Level);
        double multiplier =
            0.5 +
            (2.5 /
            (1 + Math.Exp(-0.45 * diff)));

        double xp = enemy.XP * multiplier;
        return xp;
    }
    public override char TurnLetter()
    {
        return Name[0];
    }
}