namespace ConsoleEditor.Tools;
public class ToolsPack
{
    public static string SpeakQuestion(string question)
    {
        Console.Write(question + ": ");
        return Console.ReadLine() ?? string.Empty;
    }
    public static void ClearSpeakQuestion(string question)
    {            
        string response = SpeakQuestion(question);
        if (string.IsNullOrEmpty(response) || response.ToLower() == "yes" || response.ToLower() == "y")
        {
            Console.Clear();
        } else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }
    public static void SeparationLine(char symbol = '-', int length = 50)
    {
        Console.WriteLine(new string(symbol, length));
    }
}
