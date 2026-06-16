namespace Fantasy1998.models.structures;
public class Church : GameObject
{
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
        return current_pos.row == other.current_pos.row && current_pos.col == other.current_pos.col;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(current_pos.row, current_pos.col);
    }
    public override char turn_letter()
    {
        return name[0];
    }
}