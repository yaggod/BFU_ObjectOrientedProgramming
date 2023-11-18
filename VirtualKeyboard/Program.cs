using VirtualKeyboard.Keyboard;

namespace VirtualKeyboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var keyboard = InitializeKeyboard();
            AddHotkeys(keyboard);
            SpamKeys(keyboard);


        }

        private static Keyboard.Keyboard InitializeKeyboard()
        {
            Keyboard.Keyboard keyboard = new Keyboard.Keyboard();

            string keysLetters = "ABCDEF";

            var Keys = keysLetters.Select(x => new Key(x.ToString()));
            foreach (var key in Keys)
            {
                try
                {
                    keyboard.AddKey(key);
                }
                catch { }
            }

            Key altKey = new Key("Alt", true);
            keyboard.AddKey(altKey);

            return keyboard;
        }

        private static void AddHotkeys(Keyboard.Keyboard keyboard)
        {
            Key key1 = keyboard.Keys.Values.First();
            Key key2 = keyboard.Keys.Values.Last();

            Action mainAction = () => ConsoleHelper.WriteLogsLine("Volume increased by 10");
            Action undoAction = () => ConsoleHelper.WriteLogsLine("Volume decreased by 10");

            KeysCombination keysCombination = new(key1, key2, mainAction, undoAction);


            keyboard.AddKeysCombination(keysCombination);
        }
        
        private static void SpamKeys(Keyboard.Keyboard keyboard)
        {
            var keys = keyboard.Keys.Values;
            foreach(Key key in keys)
            {
                keyboard.PressKey(key);
            }

            for(int i  = 0; i < 5; i++)
            {
                keyboard.Undo();
            }

        }

    }
}