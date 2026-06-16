using ConsoleEditor.Tools.Errors;
using Fantasy1998;
using Fantasy1998.world;

namespace ConsoleEditor.Tools;

public class OptionsMenu
{
    // Estado de seleção de cada opção
    public bool[] selection_states { get; set; }

    // Texto exibido para cada opção
    public string[] option_display_texts { get; set; }

    // Opções formatadas para exibição
    public string[] formatted_options { get; set; }

    // Marcador visual da opção selecionada
    private string _selected_option_marker { get; set; }

    // Índice atualmente selecionado
    private int _selected_index = 0;

    public OptionsMenu(string customSelectionMarker, params string[] optionDisplayTexts)
    {
        option_display_texts = optionDisplayTexts;

        selection_states = new bool[option_display_texts.Length];
        formatted_options = new string[option_display_texts.Length];

        _selected_option_marker = " " + customSelectionMarker + " ";

        if (_selected_index >= 0 && _selected_index < selection_states.Length)
        {
            selection_states[_selected_index] = true;
        }
        else
        {
            throw new Exception("Índice inicial inválido.");
        }

        for (int i = 0; i < option_display_texts.Length; i++)
        {
            string marker = selection_states[i]
                ? _selected_option_marker
                : string.Empty;

            formatted_options[i] = marker + option_display_texts[i];
        }
    }

    // Retorna o texto da opção escolhida
    public string start(string message, World map)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Screen.render_map(map);
            Console.WriteLine(message);
            _render_menu();

            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    _up_select();
                    break;
                case ConsoleKey.DownArrow:
                    _down_select();
                    break;
                case ConsoleKey.Enter:
                    isRunning = false;
                    break;
            }
        }
        return option_display_texts[_selected_index];
    }

    private void _show()
    {
        foreach (var option in formatted_options)
        {
            Console.WriteLine(option);
        }
    }

    private void _render_menu()
    {
        for (int i = 0; i < selection_states.Length; i++)
        {
            string marker = selection_states[i]
                ? _selected_option_marker
                : "   ";
            formatted_options[i] = marker + option_display_texts[i];
        }

        _show();
    }

    private void _up_select()
    {

        if (_selected_index > 0)
        {
            selection_states[_selected_index] = false;
            _selected_index--;
            selection_states[_selected_index] = true;
        }
    }

    private void _down_select()
    {
        if (_selected_index < selection_states.Length - 1)
        {
            selection_states[_selected_index] = false;
            _selected_index++;
            selection_states[_selected_index] = true;
        }
    }
}