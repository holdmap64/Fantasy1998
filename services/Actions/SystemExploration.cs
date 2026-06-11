public class SystemExploration : InputService
{
    private (int row, int col) _pos;
    public SystemExploration(Player player) : base(player)
    {
        _pos = player.CurrentPos;
    }
    public override void GameState(string nameMap)
    {
        while(GameLoop)
        {
            Player.Maps[nameMap].RenderMap();
            StoreKey = Input();
            switch(StoreKey)
            {
                case ConsoleKey.LeftArrow:
                    _pos.col--;
                    Player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.RightArrow:
                    _pos.col++;
                    Player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.UpArrow:
                    _pos.row--;
                    Player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.DownArrow:
                    _pos.row++;
                    Player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.Q:
                    GameLoop = false;
                    break;
            }
        }
    }
}