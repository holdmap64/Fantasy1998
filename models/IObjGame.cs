public interface IObjGame
{
    (int row, int col) CurrentPos { get; set; }
    string TurnLetter();
}