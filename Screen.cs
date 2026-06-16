using System.Text;
using Fantasy1998.models.player;
using Fantasy1998.world;

namespace Fantasy1998;
public class Screen
{
    public static void render_map(World maps)
    {
        Console.Clear();
        Console.Write(" ");
        for (int i = 0; i < maps.grid.GetLength(1); i++)
        {
            Console.Write(" " + (char)(65 + i));
        }
        Console.WriteLine();
        for (int row = 0; row < maps.grid.GetLength(0); row++)
        {
            for (int col = 0; col < maps.grid.GetLength(1); col++)
            {
                if (col == 0)
                    Console.Write(row);

                if (maps.grid[row, col] != null)
                    Console.Write(" " + maps.grid[row, col]?.turn_letter());
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }
}