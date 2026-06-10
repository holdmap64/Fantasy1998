public class Movement : InputService
{
    private (int row, int col) _pos;
    public Movement(Player player) : base(player)
    {
        _pos = player.CurrentPos;
    }
    public override void GameplayState(string nameMap)
    {
        HasMap(nameMap);
        while(_gameLoop)
        {
            _player.maps[nameMap].RenderMap();
            _input = Console.ReadKey(true);
            switch(_input.Key)
            {
                case ConsoleKey.LeftArrow:
                    _pos.col--;
                    _player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.RightArrow:
                    _pos.col++;
                    _player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.UpArrow:
                    _pos.row--;
                    _player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.DownArrow:
                    _pos.row++;
                    _player.MovePlayer(ref _pos, nameMap);
                    break;
                case ConsoleKey.Q:
                    _gameLoop = false;
                    break;
            }
        }
    }
}