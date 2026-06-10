public class Player : IConcreteObject
{
    public Dictionary<string, World> maps { get; private set; } = new();
    public (int row, int col) CurrentPos { get; set; }
    public Player(int row, int col)
    {
        CurrentPos = (row, col);
    }
    public void MovePlayer(ref (int row, int col) newPos, string nameMap)
    {
        if(maps[nameMap].Grid[newPos.row, newPos.col] != null)
        {
            
        } else
        {
            maps[nameMap].Grid[CurrentPos.row, CurrentPos.col] = null;
            CurrentPos = newPos;
            maps[nameMap].Grid[CurrentPos.row, CurrentPos.col] = this.TurnLetter();
            maps[nameMap].RenderMap();
        }
    }
    public void AddMap(string nameMap, World makeMap)
    {
        maps.Add(nameMap, makeMap);
    }
    private void _talkWith(string nameMap, IConcreteObject objChar)
    {
        
    }
    public string TurnLetter()
    {
        return "p";
    }
}