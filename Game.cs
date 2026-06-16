using Fantasy1998.models.player;
using Fantasy1998.services.enums;
using Fantasy1998.world;
using Fantasy1998.world.error;

namespace Fantasy1998.services;
public class Game
{
    public Game(string name_map)
    {
        GameLoop.cycle = true;
        GameLoop.state = GameState.Exploration;
        ToPlay(name_map);
    }
    private void ToPlay(string name_map)
    {
        ShippingService shipping = new ShippingService(name_map);
        while(GameLoop.cycle)
        {
            switch(GameLoop.state)
            {
                case GameState.Exploration:
                    Screen.render_map(shipping.map);
                    shipping.movement_keys(_input());
                    break;
                case GameState.Combat:

                    break;
                case GameState.Management:

                    break;
                case GameState.Exit:
                    GameLoop.cycle = false;
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