public abstract class InputService
{
    protected ConsoleKey StoreKey { get; set; }
    protected Player Player { get; set; }
    protected bool GameLoop { get; set; } 
    public InputService(Player player)
    {
        Player = player;
        GameLoop = true;
    }
    public abstract void GameState(string nameMap);
    public ConsoleKey Input()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        return keyInfo.Key;
    }
}