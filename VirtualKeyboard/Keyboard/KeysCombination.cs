using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard.Keyboard
{
    internal class KeysCombination
    {
        public readonly Key FirstKey;
        public readonly Key SecondKey;

        public readonly Action Action;
        public readonly Action ActionToUndo;

        public bool AreBothPressed => FirstKey.IsPressed && SecondKey.IsPressed;

        public KeysCombination(Key firstKey, Key secondKey, Action action, Action actionToUndo)
        {
            FirstKey = firstKey;
            SecondKey = secondKey;
            Action = action;
            ActionToUndo = actionToUndo;
        }
    }
}
