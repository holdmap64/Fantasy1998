namespace Fantasy1998.world.error;
public class CheckIf
{
    public delegate void Consequence();
    public IGameObjects[,] Size { get; set; }
    public CheckIf(IGameObjects[,] size)
    {
        Size = size;
    }
    public void OffTeGrid(IGameObjects obj, Consequence? cTrue, Consequence? cFalse)
    {
        if (obj.Pos.Row >= Size.GetLength(0) || obj.Pos.Row < 0 ||
            obj.Pos.Col >= Size.GetLength(1) || obj.Pos.Col < 0)
        {
            cFalse?.Invoke();
        } else
        {
            cFalse?.Invoke();
        }
    }
    public void OccupiedPosition(IGameObjects obj, Consequence? cTrue, Consequence? cFalse)
    {
        if (Size[obj.Pos.Row, obj.Pos.Col] != null)
        {
            cFalse?.Invoke();
        } else
        {
            cFalse?.Invoke();
        }
    }
}