using Fantasy1998.models;
public interface IGameObjects
{
    string Name { get; set; }
    (int Row, int Col) Pos { get; set; }
    char TurnLetter();
}