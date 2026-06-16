namespace Fantasy1998.models.player;
public class Player : GameObject
{
    public Player(string name, (int row, int col) current_pos) : base(name, current_pos)
    {

    }
    public override char turn_letter()
    {
        return name[0];
    }
}