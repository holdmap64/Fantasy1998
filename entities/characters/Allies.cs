public class Allies : Character, IConcreteObject {
    public (int row, int col) CurrentPos { get; set; }
    public Allies(char charId, (int row, int col) currentPos) : base(charId)
    {
        CurrentPos = currentPos;
    }
    public override bool Equals(object? obj)
    {
        if(!(obj is Allies))
        {
            return false;
        }
        Allies other = (Allies)obj;
        return CurrentPos.row == other.CurrentPos.row && CurrentPos.col == other.CurrentPos.col;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(CurrentPos.row, CurrentPos.col);
    }
    public string TurnLetter()
    {
        return CharId.ToString();
    }
}
