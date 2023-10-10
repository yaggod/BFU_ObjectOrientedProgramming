namespace ExtendedConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExtendedConsole.ShouldUseTheSameCharacter = true;
            ExtendedConsole.CharacterToUse = '*';

            ExtendedConsole.Write("hello", ExtendedConsole.FontSize.Small, 3, 3, ConsoleColor.Red);
            ExtendedConsole.Write("hello", ExtendedConsole.FontSize.Large, 6, 3, ConsoleColor.Green);
            ExtendedConsole.Write("hello", ExtendedConsole.FontSize.Medium, 12, 3, ConsoleColor.Blue);
        }
    }
}