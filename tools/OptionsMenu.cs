using ConsoleEditor.Tools.Errors;
namespace ConsoleEditor.Tools;
public class OptionsMenu
{
    // Estado de seleção de cada opção (true = selecionado, false = não, null = indefinido)
    public bool[] selection_states { get; set; }
    // Texto exibido ao lado da marcação (ex: "Opção 1", "Configuração A")
    public string[] option_display_texts { get; set; }
    // Representação completa da opção (ex: "[x] Opção 1")
    public string[] formatted_options { get; set; }
    // Texto que representa visualmente uma opção selecionada (ex: "[x]" ou ">")
    private string _selected_option_marker { get; set; }
    // Indice atual selecionado
    private int _selected_index = 0;
    public OptionsMenu(string customSelectionMarker, params string[] optionDisplayTexts)
    {
        // Guardar textos
        option_display_texts = optionDisplayTexts;

        // Inicializar tamanho dos arrays
        selection_states = new bool[option_display_texts.Length];
        formatted_options = new string[optionDisplayTexts.Length];

        // Definir marcador (ex: " > ")
        _selected_option_marker = " " + customSelectionMarker + " ";

            // se indice atual for menor que 0 e maior que tamanho permitido, Error!
            // se não indice atual vai está estado de seleção
        if (_selected_index >= 0 && _selected_index < selection_states.Length) { 
            selection_states[_selected_index] = true;
        } else
        {
            throw new Exception("Error!!!");
        }
        // Montar opções formatadas
        for (int i = 0; i < option_display_texts.Length; i++)
        {
            string marker = selection_states[i]
                ? _selected_option_marker
                : string.Empty;

            formatted_options[i] = marker + option_display_texts[i];
        }
    }
    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            _render_menu();
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key) {
                case ConsoleKey.UpArrow:
                    _up_select();
                    break;
                case ConsoleKey.DownArrow:
                    _down_select();
                    break;
                case ConsoleKey.Enter:
                    _enter_select();
                    isRunning = false;
                    break;
                default:
                    isRunning = false;
                    continue;
            }
        }
    }
    public void show()
    {
        foreach (var option in formatted_options)
        {
            System.Console.WriteLine(option);
        }
    }
    private void _render_menu()
    {
        Console.Clear();
        for (int i = 0; i < selection_states.Length; i++)
        {
            string marker = selection_states[i]
                ? _selected_option_marker
                : "   ";

            formatted_options[i] = marker + option_display_texts[i];
        }
        show();
    }
    private void _up_select()
    {
        if(_selected_index - 1 != -1)
        {
            selection_states[_selected_index] = false;
            _selected_index -= 1;
            selection_states[_selected_index] = true;
            _render_menu();
        }
    }
    private void _down_select()
    {
        if(!(_selected_index >= selection_states.Length - 1))
        {
            selection_states[_selected_index] = false;
            _selected_index += 1;
            selection_states[_selected_index] = true;
            _render_menu();
        }
    }
    private void _enter_select()
    {
        Console.WriteLine();
        System.Console.WriteLine($"Você selecionou o {option_display_texts[_selected_index]}");
    }
}
