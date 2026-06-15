using Fantasy1998.models;
using Fantasy1998.models.characters;
using Fantasy1998.models.player;
using Fantasy1998.models.structures;
using Fantasy1998.services.enums;
using Fantasy1998.world;

namespace Fantasy1998.services;
public class ShippingService
{
    public World map                { get; private set; }
    public Player player            { get; private set; }
    private GameState _state        { get; set; }
    public ShippingService(string name_map)
    {
        map = WorldsManager.get_map(name_map);
        player = WorldsManager.get_player(name_map);
        _state = GameState.Exploration;
    }
    public GameState movement_keys(ConsoleKey k)
    {
        switch(k)
        {
            case ConsoleKey.UpArrow:
                _walking_rendering(_change_position(-1, 0));
                return _state;
            case ConsoleKey.DownArrow:
                _walking_rendering(_change_position(1, 0));
                return _state;
            case ConsoleKey.RightArrow:
                _walking_rendering(_change_position(0, 1));
                return _state;
            case ConsoleKey.LeftArrow:
                _walking_rendering(_change_position(0, -1));
                return _state;
            case ConsoleKey.Escape:
                _state = GameState.Exit; 
                return _state;
            default:
                return _state;
        }
    }
    private void _walking_rendering((int row, int col) next_pos)
    {
        map.grid[player.current_pos.row, player.current_pos.col] = null;
        player.current_pos = next_pos;
        map.grid[next_pos.row, next_pos.col] = player;
    }
    private (int Row, int Col) _change_position(int row, int col)
    {
        (int row, int col) next_pos = (player.current_pos.row + row, player.current_pos.col + col);
        next_pos = _calculate_target(next_pos.row, next_pos.col);
        return next_pos; 
    }
    private (int Row, int Col) _calculate_target(int Row, int Col)
    {
        (int Row, int Col) direction = (Row, Col);
        if(direction.Row >= map.grid.GetLength(0) || direction.Row < 0 ||
            direction.Col >= map.grid.GetLength(1) || direction.Col < 0)
        {
            return player.current_pos;
        } else
        {
            direction = _resolve_interaction(direction);
            return direction;
        }
    }
    private (int Row, int Col) _resolve_interaction((int Row, int Col) targetPos)
    {
        if(map.grid[targetPos.Row, targetPos.Col] != null)
        {
            IGameObject gameObject = map.grid[targetPos.Row, targetPos.Col];
            switch(gameObject)
            {
                case Allies:
                    Console.WriteLine("Você encontrou o(a) " + gameObject.name);
                    Console.ReadKey(true);
                    return player.current_pos;
                case Enemies:
                    Console.WriteLine("Você encontrou o(a) " + gameObject.name);
                    Console.ReadKey(true);
                    return player.current_pos;
                case Church:
                    Console.WriteLine("Você encontrou o(a) " + gameObject.name);
                    Console.ReadKey(true);
                    return player.current_pos;
                default:
                    return targetPos;
            }
        }
        return targetPos;
    }
}