using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard
{
    internal class ConsoleHelper
    {
        private static int _contentLine = 0;
        private static int _logsLine = 0;


        public static void WriteLine(string text)
        { 
            Console.SetCursorPosition(0, _contentLine++);
            Console.WriteLine(text); 
        }

        public static void WriteLogsLine(string text)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, _logsLine++);
            Console.WriteLine(text);
        }

        public static void Undo()
        {
            Console.SetCursorPosition(0, --_contentLine);
            for (int i = 0; i < Console.BufferWidth / 2; i++)
                Console.Write(' ');
        }

    }
}
