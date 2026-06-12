namespace Fantasy1998.services;
public class InputService
{
    private bool _gameLoop   { get; set; }
    private GameState _state { get; set; }
    public InputService()
    {
        _state = GameState.Exploration; 
        _gameLoop = true;
    }
    public void PlayerActions()
    {
        while(_gameLoop)
        {
            switch(_state)
            {
                case GameState.Exploration:
                    break;
                case GameState.Combat:
                    break;
                case GameState.Management:
                    break;
                case GameState.Exit:
                    _gameLoop = false;
                    break;
            }
        }
    }
    private ConsoleKey _returnInputKeyboard()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        return keyInfo.Key;
    }
}