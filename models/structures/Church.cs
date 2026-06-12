namespace Fantasy1998.models.structures;
public class Church : IGameObjects 
{
    public string Name { get; set; }
    public (int Row, int Col) Pos { get; set; }
    public Church(string name, (int row, int col) pos)
    {
        Name = name;
        Pos = pos;
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Church))
        {
            return false;
        }
        Church other = (Church)obj;
        return Pos.Row == other.Pos.Row && Pos.Col == other.Pos.Col;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Pos.Row, Pos.Col);
    }
    public char TurnLetter()
    {
        return Name[0];
    }
}