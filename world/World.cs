using Fantasy1998.world.error;

namespace Fantasy1998.world;
public class World
{
    public IGameObjects[,] Size       { get; set; }
    public HashSet<IGameObjects> Objs { get; set; } = new();
    private CheckIf _checkIf;
    public World(int rows, int cols)
    {
        Size = new IGameObjects[rows, cols];
        _checkIf = new CheckIf(Size);
    }
    public void AddObject(IGameObjects obj)
    {
        _checkIf.OccupiedPosition(obj, () => throw new WorldException("Posição ocupada!!!"), null);
        _checkIf.OffTeGrid(obj, () => throw new WorldException("Posição fora do mapa!!!"),   null);
        Objs.Add(obj);
        Size[obj.Pos.Row, obj.Pos.Col] = obj;
    }
}