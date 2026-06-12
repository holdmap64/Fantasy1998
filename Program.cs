using Fantasy1998.world;
using Fantasy1998.world.error;
using Fantasy1998.models.characters;
using Fantasy1998.models.player;
using Fantasy1998.models.structures;

namespace Fantasy1998;
public class Program {
    public static void Main(string[] args)
    {
        try
        {   
            Player player = new Player("Player1", (0, 0));
            WorldsManager worldsManager = new WorldsManager();
            worldsManager.AddMap("Vila Pelicanos", new World(10, 20));
            worldsManager.GetMap("Vila Pelicanos").AddObject(player);
            worldsManager.GetMap("Vila Pelicanos").AddObject(new Allies("José", (0, 10)));
            worldsManager.GetMap("Vila Pelicanos").AddObject(new Church("Igreja Católica", (1, 11)));
            Screen.Show(worldsManager, "Vila Pelicanos");
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
