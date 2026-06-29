using Fantasy1998.models;
using Fantasy1998.models.characters;

public class Enemies : GameObject, IEnemies {
    public double Health     { get; set; }
    public double Stamina    { get; set; }
    public double Mana       { get; set; }
    public double MaxHealth  { get; set; }
    public double MaxStamina { get; set; }
    public double MaxMana    { get; set; }
    public double AP         { get; set; }
    public double AD         { get; set; }
    public double Armor      { get; set; }
    public double MR         { get; set; }
    public double Speed      { get; set; }
    public double XP         { get; set; }
    public double MaxXP      { get; set; }
    public int Level        { get; set; }
    public Enemies(string name, (int row, int col) currentPos) : base(name, currentPos)
    {

    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Enemies))
        {
            return false;
        }
        Enemies other = (Enemies)obj;
        return CurrentPos.row == other.CurrentPos.row && CurrentPos.col == other.CurrentPos.col;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(CurrentPos.row, CurrentPos.col);
    }
    public override char TurnLetter()
    {
        return Name[0];
    }
}
