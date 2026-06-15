using Fantasy1998.models.player;
using Fantasy1998.world.error;

namespace Fantasy1998.world;
public static class WorldsManager
{
    private static Dictionary<string, World> _maps = new();
    public static void add_map(World make_map)
    {
        _maps.Add(make_map.name, make_map);
    }
    public static void remove_map(string name_map)
    {
        _maps.Remove(name_map);
    }
    public static List<T> GetObjects<T>(string name_map)
    {
        List<T> list = new();
        foreach(var obj in get_map(name_map).game_objects)
        {
            if(obj is T && obj != null)
            {
                list.Add((T)obj);
            }
        }
        return list;
    }
    public static Player get_player(string name_map)
    {
        List<Player> players = GetObjects<Player>(name_map);
        if(players.Count > 1)
        {
            throw new WorldException("Não pode existir + de um player no mapa.");
        } else
        {
            if(players == null)
            {
                throw new WorldException("Não existir um player no mapa.");
            }
        }
        return players.First();
    }
    public static World get_map(string name_map)
    {
        if(_maps.TryGetValue(name_map, out World? map))
        {
            return map ?? throw new WorldException("Esse mapa está nulo!");
        }
        throw new WorldException("Esse mapa não existe!");
    }
}