public class Program {
    public static void Main(string[] args)
    {
        try
        {
            ConsoleKeyInfo input;
            int l = 0, c = 0;
            bool gameLoop = true;
            
            Player player = new Player(l, c);
            World map = new World(player, 10, 20);
            map.AddObject((1, 3), new Allies("Chico Bento"));
            map.AddObject((1, 5), new Church("Igreja Católica"));
            while(gameLoop)
            {
                map.RenderMap();
                input = Console.ReadKey(true);
                switch(input.Key)
                {
                    case ConsoleKey.LeftArrow:
                        c--;
                        map.MovePlayer((l, c));
                        break;
                    case ConsoleKey.RightArrow:
                        c++;
                        map.MovePlayer((l, c));
                        break;
                    case ConsoleKey.UpArrow:
                        l--;
                        map.MovePlayer((l, c));
                        break;
                    case ConsoleKey.DownArrow:
                        l++;
                        map.MovePlayer((l, c));
                        break;
                    case ConsoleKey.Q:
                        gameLoop = false;
                        break;
                    
                }
            }
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
