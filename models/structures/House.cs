namespace Fantasy1998.models.structures;
public class House : GameObject
{
    // Gerenciar seu time e recursos e você pode ver suas informações e tem mais você pode criar ferramentas, moveis e materiais 
    // primas que é usada para vender e ganhar dinheiro.
    public House(string name, (int row, int col) current_pos) : base(name, current_pos)
    {

    }
    public override bool Equals(object? obj)
    {
        if(!(obj is House))
        {
            return false;
        }
        House other = (House)obj;
        return current_pos.row == other.current_pos.row && current_pos.col == other.current_pos.col;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(current_pos.row, current_pos.col);
    }
    public override char turn_letter()
    {
        return name[0];
    }
}