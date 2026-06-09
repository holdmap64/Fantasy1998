public sealed class World
{
    public string?[,] Grid { get; set; }
    public Player Player { get; set; }
    private Dictionary<(int row, int col), Character> _characters = new();
    private Dictionary<(int row, int col), Structure> _buildings = new();
    public World(Player player, int rows, int cols)
    {
        Player = player;
        Grid = new string[rows, cols];
        _validatePosition((player.Row, player.Col));
        _validateOccupancy((player.Row, player.Col));
        Grid[player.Row, player.Col] = player.ToString();
    }
    public void AddObject((int row, int col) pos, Character obj)
    {
        _validatePosition(pos);
        _validateOccupancy(pos);
        _characters.Add(pos, obj);
        Grid[pos.row, pos.col] = obj.ToString();
    }
    public void AddObject((int row, int col) pos, Structure obj)
    {
        _validatePosition(pos);
        _validateOccupancy(pos);
        _buildings.Add(pos, obj);
        Grid[pos.row, pos.col] = obj.ToString();
    }
    public void MovePlayer((int row, int col) newPos)
    {
        _validatePosition(newPos);
        _validateOccupancy(newPos);
        Grid[Player.Row, Player.Col] = null;
        Player.MoveTo(newPos);
        Grid[Player.Row, Player.Col] = Player.ToString();
        RenderMap();
    }
    private void _validatePosition((int row, int col) pos)
    {
        if (pos.row >= Grid.GetLength(0) || pos.row < 0 ||
            pos.col >= Grid.GetLength(1) || pos.col < 0)
        {
            Console.Clear();
            throw new WorldException("Position is out of world bounds!");
        }
    }
    private void _validateOccupancy((int row, int col) pos)
    {
        if (_isBusy(pos))
        {
            Console.Clear();
            throw new WorldException("Position is already occupied!");
        }
    }
    private bool _isBusy((int row, int col) pos)
    {
        if (Grid[pos.row, pos.col] != null)
        {
            return true;
        }
        return false;
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
}