public interface IConcreteObject
{
    (int row, int col) CurrentPos { get; set; }
    string TurnLetter();
}