using Fantasy1998.models.player;
using Fantasy1998.services.enums;
using Fantasy1998.world;
using Fantasy1998.world.error;

namespace Fantasy1998.services;
public class Game
{
    public GameState State { private get; set; }
    public Game(string nameMap)
    {
        State = GameState.Exploration;
        ToPlay(nameMap);
    }
    private void ToPlay(string nameMap)
    {
        ShippingService shipping = new ShippingService(WorldsManager.GetMap(nameMap), 
        WorldsManager.GetPlayer(nameMap));
        switch(State)
        {
            case GameState.Exploration:
                shipping.MovementKeys();
                break;
            case GameState.Combat:

                break;
            case GameState.Management:
                
                break;
        }
    }
}