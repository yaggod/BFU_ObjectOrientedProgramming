using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedConsole
{
    internal static class ExtendedConsole
    {
        public enum FontSize : int
        {
            Small = 1,
            Medium = 3,
            Large = 4
        };

        public static bool ShouldUseTheSameCharacter
        {
            get;
            set;
        } = false;

        public static char CharacterToUse
        {
            get;
            set;
        } = '&';


        const char emptyChar = '\0';
        const ConsoleColor defaultColor = ConsoleColor.White;




        public static void Write(string message, FontSize fontSize, int x, int y, ConsoleColor color = defaultColor)
        {
            int fontSizeValue = (int)fontSize;

            for (int i = 0; i < message.Length; i++)
            {
                Write(message[i], fontSize, x, y + fontSizeValue * i + fontSizeValue/ 2 * i, color);
            }
        }


        public static void Write(char letter, FontSize fontSize, int x, int y, ConsoleColor color = defaultColor)
        {
            Console.ForegroundColor = color;
            int fontSizeValue = (int)fontSize;
            char[,] lettersMatrix = GetLettersMatrix(letter, fontSize);  
            for(int i = 0; i < fontSizeValue; i++)
                for(int j = 0; j < fontSizeValue; j++)
                {
                    WriteCharAt(lettersMatrix[i, j], x + i, y + j);
                }
            Console.ForegroundColor = defaultColor;
        }

        public static void WriteCharAt(char character, int x, int y)
        {
            Console.SetCursorPosition(y, x);
            Console.WriteLine(character);
        }


        private static char[,] GetLettersMatrix(char letter, FontSize fontSize)
        {
            int fontSizeValue = (int)fontSize;

            char[,] matrix = new char[fontSizeValue, fontSizeValue];
            if(fontSize == FontSize.Small)
            { 
                matrix[0, 0] = letter;
                return matrix;
            }

            try
            {
                string filePath = Path.Combine("letters", fontSizeValue.ToString(), letter + ".txt");
                using (var fileStream = File.OpenRead(filePath))
                {
                    byte[] tempValues = new byte[fontSizeValue * fontSizeValue];
                    fileStream.Read(tempValues, 0, tempValues.Length);

                    CopyDataToCharsMatrix(matrix, tempValues, fontSizeValue);
                }
            }
            catch { }

            return matrix;
        }

        private static void CopyDataToCharsMatrix(char[,] destination, byte[] source, int fontSize)
        {
            for (int i = 0; i < source.Length; i++)
            {
                int firstIndex = i / fontSize;
                int secondIndex = i % fontSize;
                if (secondIndex >= fontSize)
                    continue;

                char currentChar = (char)source[i];
                currentChar = currentChar == ' ' ? emptyChar : currentChar;
                if(ShouldUseTheSameCharacter)
                {
                    currentChar = currentChar == '\0' ? emptyChar : CharacterToUse;
                }
                destination[firstIndex, secondIndex] = currentChar;

            }

        }

    }
}
