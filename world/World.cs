using Fantasy1998.models;
using Fantasy1998.world.error;

namespace Fantasy1998.world;
public class World
{
    public string Name                       { get; set; }
    public GameObject?[,] Grid              { get; set; }
    public HashSet<GameObject> GameObjects { get; set; } = new();
    public World(string name, int rows, int cols)
    {
        Name = name;
        Grid = new GameObject[rows, cols];
    }
    public void AddObject(GameObject obj)
    {
        _offTheGrid(obj);
        _positionOccupied(obj);
        GameObjects.Add(obj);
    }
    public void Mapping()
    {
        foreach(GameObject obj in GameObjects)
        {
            Grid[obj.CurrentPos.row, obj.CurrentPos.col] = obj;
        }
    }
    private void _offTheGrid(GameObject obj)
    {
        if (obj.CurrentPos.row >= Grid.GetLength(0) || obj.CurrentPos.row < 0 ||
            obj.CurrentPos.col >= Grid.GetLength(1) || obj.CurrentPos.col < 0)
        {
            throw new WorldException("Posição fora do mapa!!!");
        }
    }
    private void _positionOccupied(GameObject obj)
    {
        if (Grid[obj.CurrentPos.row, obj.CurrentPos.col] != null)
        {
            throw new WorldException("Posição ocupada!!!");
        }
    }
}