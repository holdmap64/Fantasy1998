namespace Fantasy1998.models.characters;
public class Allies : IGameObjects {
    public string Name { get; set; }
    public (int Row, int Col) Pos { get; set; }
    public Allies(string name, (int row, int col) pos)
    {
        Name = name;
        Pos = pos;
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Allies))
        {
            return false;
        }
        Allies other = (Allies)obj;
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
