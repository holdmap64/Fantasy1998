using Fantasy1998.world;
using Fantasy1998.world.error;
using Fantasy1998.models.characters;
using Fantasy1998.models.player;
using Fantasy1998.models.structures;
using Fantasy1998.services;

namespace Fantasy1998;
public class Program {
    public static void Main(string[] args)
    {
        try
        {   
            Player player = new Player("Player1", (0, 0)); // Player(string name, (int Row, int Col) pos)
            // Adicionar um World.cs(classe):
            WorldsManager.add_map(new World("Vila Pelicanos", 10, 20)); // WorldsManager.AddMap(World makeMap)
            // Adicionar IGameObjects:
            WorldsManager.get_map("Vila Pelicanos").add_object(player);
            WorldsManager.get_map("Vila Pelicanos").add_object(new Allies("José", (0, 10)));
            WorldsManager.get_map("Vila Pelicanos").add_object(new Enemies("Goblin", (4, 5)));
            WorldsManager.get_map("Vila Pelicanos").add_object(new Church("Igreja Católica", (1, 11)));
            WorldsManager.get_map("Vila Pelicanos").mapping();
            // -------------------------------------------------------------------------------------------------------------
            PlayerService playerService = new PlayerService("Vila Pelicanos");
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
