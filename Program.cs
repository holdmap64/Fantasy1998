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

            // Adicionar um objeto do tipo World no dicionário estático _maps:
            // Mas por que fiz isso?
            // O estático vai ser util pois a obtenção de uma propriedade é imediatada pois a a propriedade faz parte da classe
            // não do objeto. E também, WorldManager é um gerenciador de vários mapas com métodos feito para modificar, obter,
            // remover e buscar.
            WorldsManager.AddMap(new World("Vila Pelicanos", 10, 20));
            // Adicionar IGameObjects:
            WorldsManager.GetMap("Vila Pelicanos").AddObject(new Player("João", (0, 0)));
            WorldsManager.GetMap("Vila Pelicanos").AddObject(new Allies("José", (0, 10)));
            WorldsManager.GetMap("Vila Pelicanos").AddObject(new Enemies("Goblin", (4, 5)));
            WorldsManager.GetMap("Vila Pelicanos").AddObject(new Church("Igreja Católica", (1, 11)));
            WorldsManager.GetMap("Vila Pelicanos").Mapping();
            // -----------------------------------------------------------------------------------------------------------------
            Game game = new Game("Vila Pelicanos");
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
