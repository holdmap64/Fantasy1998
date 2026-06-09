public class Player
{
    private (int row, int col) _currentPos;
    public int Row => _currentPos.row;
    public int Col => _currentPos.col;
    public Player(int row, int col)
    {
        _currentPos = (row, col);
    }
    public void MoveTo((int row, int col) newPos)
    {
        _currentPos = newPos;
    }
    public override string ToString() => "p";
}