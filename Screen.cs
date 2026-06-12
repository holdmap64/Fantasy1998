using Fantasy1998.models.player;
using Fantasy1998.world;

namespace Fantasy1998;
public class Screen
{
    public static void Show(WorldsManager maps, string nameMap)
    {
        Console.Clear();
        Console.Write(" ");
        for (int i = 0; i < maps.GetExistingMap(nameMap).Size.GetLength(1); i++)
        {
            Console.Write(" " + (char)(65 + i));
        }
        Console.WriteLine();
        for (int row = 0; row < maps.GetExistingMap(nameMap).Size.GetLength(0); row++)
        {
            for (int col = 0; col < maps.GetExistingMap(nameMap).Size.GetLength(1); col++)
            {
                if (col == 0)
                    Console.Write(row);

                if (maps.GetExistingMap(nameMap).Size[row, col] != null)
                    Paint.PaintText(" " + maps.GetExistingMap(nameMap).Size[row, col].TurnLetter(), ConsoleColor.Yellow);
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }
}