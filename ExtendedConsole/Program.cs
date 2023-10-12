namespace ExtendedConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExtendedConsole.ShouldUseTheSameCharacter = true;
            ExtendedConsole.CharacterToUse = '4';

            ExtendedConsole.Write("HELLO", ExtendedConsole.FontSize.Small, 3, 3, ConsoleColor.Red);
            ExtendedConsole.Write("HELLO", ExtendedConsole.FontSize.Large, 6, 3, ConsoleColor.Green);
            ExtendedConsole.Write("HELLO", ExtendedConsole.FontSize.Medium, 12, 3, ConsoleColor.Blue);
        }
    }
}