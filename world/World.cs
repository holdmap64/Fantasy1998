public class World
{
    public string?[,] Grid { get; set; }
    public Player player { get; set; }
    public World(Player player, int rows, int cols)
    {
        this.player = player;
        Grid = new string[rows, cols];
        _spawnPlayer();
    }
    public void AddObject(IConcreteObject obj)
    {
        LaunchPositionError(obj);
        Grid[obj.CurrentPos.row, obj.CurrentPos.col] = obj.TurnLetter();
    }
    public void RenderMap()
    {
        Console.Clear();

        // Column headers
        Console.Write(" ");
        for (int i = 0; i < Grid.GetLength(1); i++)
        {
            Console.Write(" " + (char)(65 + i));
        }
        Console.WriteLine();

        // Map rows
        for (int row = 0; row < Grid.GetLength(0); row++)
        {
            for (int col = 0; col < Grid.GetLength(1); col++)
            {
                if (col == 0)
                    Console.Write(row);

                if (Grid[row, col] != null)
                    Paint.PaintText(" " + Grid[row, col], ConsoleColor.Yellow);
                else
                    Console.Write(" -");
            }
            Console.WriteLine();
        }
    }
    private bool _outPosition((int row, int col) pos)
    {
        if (pos.row >= Grid.GetLength(0) || pos.row < 0 ||
            pos.col >= Grid.GetLength(1) || pos.col < 0)
        {
            return true;
        }
        return false;
    }
    private bool _isBusy((int row, int col) pos)
    {
        if (!(Grid[pos.row, pos.col] == null))
        {
            return true;
        }
        return false;
    }
    public void LaunchPositionError(IConcreteObject obj)
    {
        if(!(obj is Player))
        {
            if(_outPosition(obj.CurrentPos))
            {
                throw new WorldException("Error in World.cs! Off the Grid");
            } else
            {
                if(_isBusy(obj.CurrentPos))
                {
                    throw new WorldException("Error in World.cs! Structures and Objects cannot be in the same location.");
                }
            }   
        }
    }
    private void _spawnPlayer()
    {
        LaunchPositionError(player);
        Grid[player.CurrentPos.row, player.CurrentPos.col] = player.TurnLetter();
    }
}