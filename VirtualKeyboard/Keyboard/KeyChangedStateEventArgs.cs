using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard.Keyboard
{
    internal class KeyChangedStateEventArgs : EventArgs
    {
        public readonly bool IsPressed;

        public KeyChangedStateEventArgs(bool isPressed)
        {
            IsPressed = isPressed;
        }
    }
}
