using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard.Keyboard
{
    internal class Key
    {
        public readonly string KeyName;
        public readonly bool IsModifierKey;

        public string TextToOutput => IsModifierKey ? string.Empty : KeyName;

        public bool IsPressed
        {
            get;
            private set;
        }


        public event EventHandler<KeyPressingEventArgs> OnKeyPressing;
        public event EventHandler<KeyChangedStateEventArgs> OnKeyPressed; 
        public event EventHandler<KeyChangedStateEventArgs> OnKeyReleased;


        public Key(string keyName, bool isModifier = false)
        {
            KeyName = keyName;
            IsModifierKey = isModifier;
        }

        public void Press()
        {
            if (!IsPressed) 
            {
                IsPressed = true;
                KeyPressingEventArgs keyPressingEventArgs = new KeyPressingEventArgs();
                OnKeyPressing?.Invoke(this, keyPressingEventArgs);
                if(keyPressingEventArgs.ShouldPress)
                    OnKeyPressed?.Invoke(this, new KeyChangedStateEventArgs(true));
            }
        }

        public void Release()
        {
            if(IsPressed)
            {
                IsPressed = false;
                OnKeyReleased?.Invoke(this, new KeyChangedStateEventArgs(false));
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Key) return false;
            Key second = (Key)obj;

            return KeyName.Equals(second.KeyName) && IsModifierKey.Equals(second.IsModifierKey);
        }

    }
}
