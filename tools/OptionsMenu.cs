namespace ConsoleEditor.Tools;

public class OptionsMenu
{
    private readonly string[] _options;
    private readonly string _selectedOptionMarker;
    private readonly Action? _headerRenderer;
    private int _selectedIndex;
    public OptionsMenu(
        string selectionMarker,
        Action? headerRenderer = null,
        params string[] options)
    {
        if (options.Length == 0)
        {
            throw new ArgumentException(
                "O menu deve possuir pelo menos uma opção.",
                nameof(options));
        }

        _options = options;
        _selectedOptionMarker = $" {selectionMarker} ";
        _headerRenderer = headerRenderer;
    }
    public string Start()
    {
        while (true)
        {
            Console.Clear();

            RenderHeader();

            RenderMenu();

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    MoveSelectionUp();
                    break;

                case ConsoleKey.DownArrow:
                    MoveSelectionDown();
                    break;

                case ConsoleKey.Enter:
                    return _options[_selectedIndex];
            }
        }
    }
    private void RenderHeader()
    {
        _headerRenderer?.Invoke();
    }
    private void RenderMenu()
    {
        for (int i = 0; i < _options.Length; i++)
        {
            string marker = i == _selectedIndex
                ? _selectedOptionMarker
                : new string(' ', _selectedOptionMarker.Length);

            Console.WriteLine($"{marker}{_options[i]}");
        }
    }
    private void MoveSelectionUp()
    {
        _selectedIndex =
            (_selectedIndex - 1 + _options.Length) % _options.Length;
    }
    private void MoveSelectionDown()
    {
        _selectedIndex =
            (_selectedIndex + 1) % _options.Length;
    }
}