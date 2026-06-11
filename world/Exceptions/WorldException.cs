public class WorldException : ApplicationException {
    public WorldException(string message) : base(message)
    {
        
    }
    public static void ThrowExceptionOccupiedBill(IObjGame objGame, IObjGame?[,] world) // Verificar se um elemento está ocupado
    {
        if (world[objGame.CurrentPos.row, objGame.CurrentPos.col] != null)
        {
            throw new WorldException("Essa posição já está ocupado.");
        }
    }
    public static void ThrowExceptionOffMap(IObjGame objGame, IObjGame?[,] world) // Verificar se um objeto está fora do mapa
    {
        if (objGame.CurrentPos.row >= world.GetLength(0) || objGame.CurrentPos.row < 0 ||
            objGame.CurrentPos.col >= world.GetLength(1) || objGame.CurrentPos.col < 0)
        {
            throw new WorldException("Essa posição está fora do mapa.");
        }
    }
}
