using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeKeyboard.Keyboard
{
    public class Key
    {
        public string KeyName
        {
            get;
        }

        public bool IsModifierKey
        {
            get;
        }

        public Key(string keyName, bool isModifier = false)
        {
            KeyName = keyName;
            IsModifierKey = isModifier;
        }

        public override bool Equals(object obj)
        {
            Key secondObject = obj as Key;
            if (secondObject == null) 
                return false;

            return IsModifierKey.Equals(secondObject.IsModifierKey) && KeyName.Equals(secondObject.KeyName);
        }

        public void Press(bool shouldType = true)
        {
            if (!IsModifierKey && shouldType)
                OutputHandler.WriteOutput(KeyName);
            OutputHandler.WriteLogs("Pressed " + KeyName);
        }
    }
}