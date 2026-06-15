using Fantasy1998.world.error;

namespace Fantasy1998.world;
public class WorldsManager
{
    private Dictionary<string, World> _maps = new();
    public void AddMap(string nameMap, World makeMap)
    {
        _maps.Add(nameMap, makeMap);
    }
    public void RemoveMap(string nameMap)
    {
        _maps.Remove(nameMap);
    }
    public World GetMap(string nameMap)
    {
        if(_maps.TryGetValue(nameMap, out World? map))
        {
            return map ?? throw new WorldException("Esse mapa está nulo!");
        }
        throw new WorldException("Esse mapa não existe!");
    }
}