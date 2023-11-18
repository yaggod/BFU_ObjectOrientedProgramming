using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard.Keyboard
{
    internal class KeyPressingEventArgs : EventArgs
    {
        public bool ShouldPress = true;
    }
}
