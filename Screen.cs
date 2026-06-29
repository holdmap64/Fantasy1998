using System.Text;
using Fantasy1998.models.player;
using Fantasy1998.world;

namespace Fantasy1998;
public class Screen
{
    public static void RenderMap(World maps)
    {
        Console.Clear();
        Console.Write(" ");
        for (int i = 0; i < maps.Grid.GetLength(1); i++)
        {
            Console.Write(" " + (char)(65 + i));
        }
        Console.WriteLine();
        for (int row = 0; row < maps.Grid.GetLength(0); row++)
        {
            for (int col = 0; col < maps.Grid.GetLength(1); col++)
            {
                if (col == 0)
                    Console.Write(row);

                if (maps.Grid[row, col] != null)
                    Console.Write(" " + maps.Grid[row, col]?.TurnLetter());
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }
}