using Fantasy1998.models;
using Fantasy1998.models.player;
using Fantasy1998.world.error;

namespace Fantasy1998.world;
public static class WorldsManager
{
    private static Dictionary<string, World> _maps = new();
    public static void AddMap(World makeMap)
    {
        _maps.Add(makeMap.Name, makeMap);
    }
    public static void RemoveMap(string nameMap)
    {
        _maps.Remove(nameMap);
    }
    public static List<T> GetObject<T>(string name_map) where T : GameObject
    {
        List<T> list = new();
        foreach(var obj in GetMap(name_map).GameObjects)
        {
            if(obj is T)
            {
                list.Add((T)obj);
            }
        }
        return list;
    }
    public static Player GetPlayer(string nameMap)
    {
        List<Player> players = GetObject<Player>(nameMap);
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
    public static World GetMap(string nameMap)
    {
        if(_maps.TryGetValue(nameMap, out World? map))
        {
            return map ?? throw new WorldException("Esse mapa está nulo!");
        }
        throw new WorldException("Esse mapa não existe!");
    }
}