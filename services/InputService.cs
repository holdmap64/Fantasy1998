using System.Runtime.InteropServices.Marshalling;
using System.Text;

public abstract class InputService
{
    protected ConsoleKeyInfo _input { get; set; }
    protected bool _gameLoop { get; set; } 
    protected Player _player { get; set; }
    public InputService(Player player)
    {
        this._player = player;
        _gameLoop = true;
    }
    public abstract void GameplayState(string nameMap);
    protected void HasMap(string nameMap)
    {
        if(!(_player.maps.ContainsKey(nameMap)))
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"O mapa ={nameMap}= não existe!");
            sb.AppendLine("----São esses mapas que existem--------------------");
            sb.AppendLine();
            foreach(var obj in _player.maps)
            {
                sb.AppendLine($" - {obj.Key}: {obj.Value}");
            }
            sb.AppendLine();
            sb.AppendLine("---------------------------------------------------");
            throw new WorldException(sb.ToString());
        }
    }
}