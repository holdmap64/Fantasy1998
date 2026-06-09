static class Paint
{
    public static void PaintText(string text, ConsoleColor f, ConsoleColor b)
    {
        Console.BackgroundColor = b;
        Console.ForegroundColor = f;
        System.Console.Write(text);
        Console.ResetColor();
    }
    public static void PaintText(string text, ConsoleColor f)
    {
        Console.ForegroundColor = f;
        System.Console.Write(text);
        Console.ResetColor();
    }
}