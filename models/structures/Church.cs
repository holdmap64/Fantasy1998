namespace Fantasy1998.models.structures;
public class Church : GameObject
{
    // Restaura a vida, mana e stamina...
    public Church(string name, (int row, int col) current_pos) : base(name, current_pos)
    {

    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Church))
        {
            return false;
        }
        Church other = (Church)obj;
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