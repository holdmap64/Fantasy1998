namespace Fantasy1998.models.player;
public class Player : IGameObject
{
    public string name { get; set; }
    public (int row, int col) current_pos { get; set; }
    public Player(string name, (int row, int col) pos)
    {
        this.name = name;
        this.current_pos = pos;
    }
    public char turn_letter()
    {
        return name[0];
    }
}