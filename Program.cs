public class Program {
    public static void Main(string[] args)
    {
        try
        {   
            Player player = new Player(0, 0);
            player.AddMap("Vila Pelicanos", new World(player, 10, 20));
            player.maps["Vila Pelicanos"].AddObject(new Allies('a', (1, 4)));
            player.maps["Vila Pelicanos"].AddObject(new Church('c', (1, 3)));
            InputService inputService = new Movement(player);
            inputService.GameplayState("Vila Pelicanos..");
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
