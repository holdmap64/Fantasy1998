using ConsoleEditor.Tools;
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
    public ShippingService(string name_map)
    {
        map = WorldsManager.get_map(name_map);
        player = WorldsManager.get_player(name_map);
    }
    public void movement_keys(ConsoleKey k)
    {
        switch(k)
        {
            case ConsoleKey.UpArrow:
                _walking_rendering(_change_position(-1, 0));
                break;
            case ConsoleKey.DownArrow:
                _walking_rendering(_change_position(1, 0));
                break;
            case ConsoleKey.RightArrow:
                _walking_rendering(_change_position(0, 1));
                break;
            case ConsoleKey.LeftArrow:
                _walking_rendering(_change_position(0, -1));
                break;
            case ConsoleKey.Escape:
                GameLoop.state = GameState.Exit; 
                break;
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
        OptionsMenu opt1 = new OptionsMenu(">", "Sim", "Não");
        if(map.grid[targetPos.Row, targetPos.Col] != null)
        {
            GameObject? gameObject = map.grid[targetPos.Row, targetPos.Col];
            switch(gameObject)
            {
                case Allies:
                    _options("Deseja fazer ele ser parte do time?");
                    return player.current_pos;
                case Enemies:
                    _options("Deseja lutar com ele?");
                    return player.current_pos;
                case Church:
                    _options("Deseja restaurar a vida e energia?");
                    return player.current_pos;
            }
        }
        return targetPos;
    }
    private string _options(string message)
    {
        OptionsMenu opt1 = new OptionsMenu(">", "Sim", "Não");
        while(true)
        {
            if(opt1.start(message, map) == "Sim")
            {
                return "Sim";
            } else
            {
                return "Não";
            }
        }
    }
}