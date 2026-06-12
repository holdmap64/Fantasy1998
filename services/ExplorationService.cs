using Fantasy1998.models.player;
using Fantasy1998.world;

namespace Fantasy1998.services;
public class ExplorationService
{
    private Player _player { get; set; }
    private World _world   { get; set; }
    public ExplorationService(Player player, World world)
    {
        _player = player;
        _world = world;
    }
}