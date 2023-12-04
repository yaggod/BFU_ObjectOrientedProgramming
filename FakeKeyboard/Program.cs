using FakeKeyboard.Keyboard;

namespace FakeKeyboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeyboardWorkflow();
        }

        private static void KeyboardWorkflow()
        {
            var keyboard = InitializeKeyboard();
            keyboard.PressKeysPair("Ctrl", "A");
            keyboard.PressKey("B");
            keyboard.PressKey("B");
            keyboard.PressKey("C");
            keyboard.PressKey("D");
            keyboard.PressKeysPair("Ctrl", "A");
            keyboard.PressKeysPair("Ctrl", "Z");
            keyboard.Undo();
            keyboard.Undo();
            keyboard.Undo();
        }

        private static Keyboard.Keyboard InitializeKeyboard()
        {
            Keyboard.Keyboard keyboard = new();

            Key[] keys = new Key[]
            {
            new("Ctrl", true),
            new("Z"),
            new("A"),
            new("B"),
            new("C"),
            new("D"),
            };

            foreach (var key in keys)
            {
                keyboard.Add(key);
            }


            KeysCombination combination1 = new(keys[0], keys[1], () => keyboard.Undo());
            KeysCombination combination2 = new(keys[0], keys[2], () => OutputHandler.WriteLogs("Volume increased by 10"), 
                                                                 () => OutputHandler.WriteLogs("Volume decreased by 10"));


            keyboard.AddKeysCombination(combination1);
            keyboard.AddKeysCombination(combination2);
            return keyboard;
        }
    }
}