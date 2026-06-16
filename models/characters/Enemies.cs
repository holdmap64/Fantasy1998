using Fantasy1998.models;

public class Enemies : GameObject {
    public Enemies(string name, (int row, int col) current_pos) : base(name, current_pos)
    {
        this.name = name;
        this.current_pos = current_pos;
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Enemies))
        {
            return false;
        }
        Enemies other = (Enemies)obj;
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
