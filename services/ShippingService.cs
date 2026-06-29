using ConsoleEditor.Tools;
using Fantasy1998.models;
using Fantasy1998.models.characters;
using Fantasy1998.models.player;
using Fantasy1998.models.structures;
using Fantasy1998.world;

namespace Fantasy1998.services;

public class ShippingService
{
    private World _map     { get; set; }
    private Player _player { get; set; }
    private bool _cycle    { get; set; }
    public ShippingService(World map, Player player)
    {
        _map = map;
        _player = player;
        _cycle = true;
    }

    public void MovementKeys()
    {
        while (_cycle)
        {
            Screen.RenderMap(_map);

            ConsoleKeyInfo data = Console.ReadKey(true);

            switch (data.Key)
            {
                case ConsoleKey.UpArrow:
                    _walkingRendering(_changePosition(-1, 0));
                    break;

                case ConsoleKey.DownArrow:
                    _walkingRendering(_changePosition(1, 0));
                    break;

                case ConsoleKey.RightArrow:
                    _walkingRendering(_changePosition(0, 1));
                    break;

                case ConsoleKey.LeftArrow:
                    _walkingRendering(_changePosition(0, -1));
                    break;

                case ConsoleKey.Escape:
                    _cycle = false;
                    break;
            }
        }
    }

    private void _walkingRendering((int Row, int Col) nextPos)
    {
        if (nextPos == _player.CurrentPos)
            return;
        _map.Grid[_player.CurrentPos.row, _player.CurrentPos.col] = null;
        _player.CurrentPos = nextPos;
        _map.Grid[nextPos.Row, nextPos.Col] = _player;
    }

    private (int Row, int Col) _changePosition(int rowOffset, int colOffset)
    {
        int nextRow = _player.CurrentPos.row + rowOffset;
        int nextCol = _player.CurrentPos.col + colOffset;

        return _calculateTarget(nextRow, nextCol);
    }

    private (int Row, int Col) _calculateTarget(int row, int col)
    {
        if (row < 0 ||
            row >= _map.Grid.GetLength(0) ||
            col < 0 ||
            col >= _map.Grid.GetLength(1))
        {
            return _player.CurrentPos;
        }

        return _resolveInteraction((row, col));
    }

    private (int Row, int Col) _resolveInteraction((int Row, int Col) targetPos)
    {
        GameObject? gameObject = _map.Grid[targetPos.Row, targetPos.Col];

        if (gameObject is null)
            return targetPos;

        switch (gameObject)
        {
            case Allies:
                // Abrir menu de aliado futuramente
                return _player.CurrentPos;

            case Enemies:
                // Iniciar batalha
                return _player.CurrentPos;

            case Church:
                // Abrir igreja
                return _player.CurrentPos;

            case Blacksmithing:
                // Abrir ferreiro
                return _player.CurrentPos;

            case House:
                // Entrar na casa
                return _player.CurrentPos;

            default:
                return targetPos;
        }
    }
}