using System.Data;
using System.Reflection.Metadata;

public class Program {
    public static void Main(string[] args)
    {
        try
        {
            ConsoleKeyInfo input;
            int l = 0, c = 0;
            
            Player player = new Player(l, c);
            World map = new World(player, 10, 20);
            map.AddObject((1, 3), new Allies("José"));
            map.AddObject((1, 5), new Church("Igreja Católica"));
            while(true)
            {
                map.RenderMap();
                input = Console.ReadKey();

                if(input.Key == ConsoleKey.C)
                {
                    break;
                } else
                {
                    switch(input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            c--;
                            break;
                        case ConsoleKey.RightArrow:
                            c++;
                            break;
                        case ConsoleKey.UpArrow:
                            l--;
                            break;
                        case ConsoleKey.DownArrow:
                            l++;
                            break;
                    }
                    map.MovePlayer((l, c));
                }
            }
        } catch(WorldException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
