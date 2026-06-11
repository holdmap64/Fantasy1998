public class World
{
    public IObjGame?[,] Grid { get; set; }
    public HashSet<IObjGame> ObjGame { get; set; } = new();
    public World(Player player, int rows, int cols)
    {
        Grid = new IObjGame[rows, cols];
        AddObject(player);
    }
    public void AddObject(IObjGame obj)
    {
        WorldException.ThrowExceptionOffMap(obj, Grid);
        WorldException.ThrowExceptionOccupiedBill(obj, Grid);
        ObjGame.Add(obj);
        Grid[obj.CurrentPos.row, obj.CurrentPos.col] = obj;
    }
    public void RenderMap()
    {
        Console.Clear();
        Console.Write(" ");
        for (int i = 0; i < Grid.GetLength(1); i++)
        {
            Console.Write(" " + (char)(65 + i));
        }
        Console.WriteLine();
        for (int row = 0; row < Grid.GetLength(0); row++)
        {
            for (int col = 0; col < Grid.GetLength(1); col++)
            {
                if (col == 0)
                    Console.Write(row);

                if (Grid[row, col] != null)
                    Paint.PaintText(" " + Grid[row, col].TurnLetter(), ConsoleColor.Yellow);
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }
}