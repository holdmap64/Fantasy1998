using Fantasy1998.models.player;
using Fantasy1998.services.enums;
using Fantasy1998.world;
using Fantasy1998.world.error;

namespace Fantasy1998.services;
public class PlayerService
{
    protected bool _state_cycle         { get; set; }
    protected GameState _type_of_states { get; set; }
    public PlayerService(string name_map)
    {
        _state_cycle = true;
        _type_of_states = GameState.Exploration;
        ToPlay(name_map);
    }
    public void ToPlay(string name_map)
    {
        ShippingService shipping = new ShippingService(name_map);
        while(_state_cycle)
        {
            switch(_type_of_states)
            {
                case GameState.Exploration:
                    Screen.render_map(shipping.map);
                    _type_of_states = shipping.movement_keys(_input());
                    break;
                case GameState.Combat:

                    break;
                case GameState.Management:

                    break;
                case GameState.Exit:
                    _state_cycle = false;
                    break;
            }
        }
    }
    private static ConsoleKey _input()
    {
        ConsoleKeyInfo data = Console.ReadKey(true);
        return data.Key;
    }
}