namespace Fantasy1998.models;
public interface IGameObject
{
    string name { get; set; }
    (int row, int col) current_pos { get; set; }
    char turn_letter();
}