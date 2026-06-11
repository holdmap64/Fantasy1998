using System.Text;
public class Player : IObjGame
{
    public Dictionary<string, World> Maps { get; private set; } = new();
    public (int row, int col) CurrentPos { get; set; }
    public Player(int row, int col)
    {
        CurrentPos = (row, col);
    }
    public void MovePlayer(ref (int row, int col) newPos, string nameMap)
    {
        _hasMap(nameMap);
        if(Maps[nameMap].Grid[newPos.row, newPos.col] != null)
        {
            switch(Maps[nameMap].Grid[newPos.row, newPos.col])
            {
                case Allies:
                    newPos = CurrentPos;
                    break;
                case Enemies:
                    newPos = CurrentPos;
                    break;
                case Church:
                    newPos = CurrentPos;
                    break;
            }
        } else
        {
            Maps[nameMap].Grid[CurrentPos.row, CurrentPos.col] = null;
            CurrentPos = newPos;
            Maps[nameMap].Grid[CurrentPos.row, CurrentPos.col] = this;
            Maps[nameMap].RenderMap();
        }
    }
    public void AddMap(string nameMap, World makeMap)
    {
        Maps.Add(nameMap, makeMap);
    }
    public void _hasMap(string nameMap)
    {
        if(!(this.Maps.ContainsKey(nameMap)))
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"O mapa ={nameMap}= não existe!");
            sb.AppendLine("----São esses mapas que existem--------------------");
            foreach(var obj in this.Maps)
            {
                sb.AppendLine($" - {obj.Key}: {obj.Value}");
            }
            sb.AppendLine("---------------------------------------------------");
            throw new WorldException(sb.ToString());
        }
    }
    private void _talkWith(string nameMap, IObjGame objGame)
    {
        
    }
    public string TurnLetter()
    {
        return "p";
    }
}