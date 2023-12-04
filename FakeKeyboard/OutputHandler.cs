using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeKeyboard
{
    public static class OutputHandler
    {
        private static int _currentTextPosition = 0;
        private static int _currentLogsPosition = 0;
        private static int _consoleMiddleWidth => Console.WindowWidth / 2;
        public static void WriteOutput(string output)
        {
            Console.SetCursorPosition(0, _currentTextPosition++);
            Console.WriteLine(output);
        }

        public static void WriteLogs(string logs)
        {
            Console.SetCursorPosition(_consoleMiddleWidth, _currentLogsPosition++);
            Console.WriteLine(logs);
        }

        public static void Undo()
        {
            Console.SetCursorPosition(0, --_currentTextPosition);
            Console.WriteLine(String.Join("", Enumerable.Repeat(' ', _consoleMiddleWidth)));
        }
    }
}
