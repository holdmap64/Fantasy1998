using Fantasy1998.models;
using Fantasy1998.world.error;

namespace Fantasy1998.world;
public class World
{
    public string name                      { get; set; }
    public IGameObject?[,] grid              { get; set; }
    public HashSet<IGameObject> game_objects { get; set; } = new();
    public World(string name, int rows, int cols)
    {
        this.name = name;
        grid = new IGameObject[rows, cols];
    }
    public void add_object(IGameObject obj)
    {
        _off_the_grid(obj);
        _position_occupied(obj);
        game_objects.Add(obj);
    }
    public void mapping()
    {
        foreach(IGameObject obj in game_objects)
        {
            grid[obj.current_pos.row, obj.current_pos.col] = obj;
        }
    }
    private void _off_the_grid(IGameObject obj)
    {
        if (obj.current_pos.row >= grid.GetLength(0) || obj.current_pos.row < 0 ||
            obj.current_pos.col >= grid.GetLength(1) || obj.current_pos.col < 0)
        {
            throw new WorldException("Posição fora do mapa!!!");
        }
    }
    private void _position_occupied(IGameObject obj)
    {
        if (grid[obj.current_pos.row, obj.current_pos.col] != null)
        {
            throw new WorldException("Posição ocupada!!!");
        }
    }
}