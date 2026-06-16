namespace Fantasy1998.models;
public abstract class GameObject
{
    public string name                    { get; set; }
    public (int row, int col) current_pos { get; set; }
    public GameObject(string name, (int row, int col) current_pos)
    {
        this.name = name;
        this.current_pos = current_pos;
    }
    public abstract char turn_letter();
}