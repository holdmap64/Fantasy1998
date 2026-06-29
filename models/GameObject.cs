namespace Fantasy1998.models;
public abstract class GameObject
{
    public string Name                   { get; set; }
    public (int row, int col) CurrentPos { get; set; }
    public GameObject(string name, (int row, int col) currentPos)
    {
        Name = name;
        CurrentPos = currentPos;
    }
    public abstract char TurnLetter();
}