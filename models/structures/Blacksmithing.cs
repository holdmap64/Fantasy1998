namespace Fantasy1998.models.structures;
public class Blacksmithing : GameObject
{
    // Melhorar ferramentas, arma e armaduras...
    public Blacksmithing(string name, (int row, int col) current_pos) : base(name, current_pos)
    {

    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Blacksmithing))
        {
            return false;
        }
        Blacksmithing other = (Blacksmithing)obj;
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