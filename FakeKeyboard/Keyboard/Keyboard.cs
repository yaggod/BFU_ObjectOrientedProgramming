using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeKeyboard.Keyboard
{
    public class Keyboard
    {
        private readonly List<Key> _keys = new();
        private readonly List<KeysCombination> _keysCombinations = new();
        private readonly Stack<Action> _actionsToUndo = new();

        public bool PressKey(string keyName, bool shouldType = true)
        {
            var keyToPress = _keys.FirstOrDefault(key => key.KeyName == keyName);
            if (keyToPress == null)
                return false;
            keyToPress.Press(shouldType);
            if(shouldType)
                _actionsToUndo.Push(() => OutputHandler.Undo());


            return true;
        }
  
        public bool PressKeysPair(string firstKey, string secondKey) 
        {
            var keysCombination = _keysCombinations
                .FirstOrDefault(combination => combination.FirstKey.KeyName == firstKey && combination.SecondKey.KeyName == secondKey);

            if(keysCombination == null)
            {
                PressKey(firstKey);
                PressKey(secondKey);
                return false;
            }


            PressKey(firstKey, false);
            PressKey(secondKey, false);
            keysCombination.Action();
            if (keysCombination.ActionToUndo != null)
                _actionsToUndo.Push(keysCombination.ActionToUndo);

            return true;
        }
        
        public void Add(Key key)
        {
            _keys.Add(key);
        }

        public bool AddKeysCombination(KeysCombination keysCombination)
        {
            if (!_keys.Contains(keysCombination.FirstKey) || !_keys.Contains(keysCombination.SecondKey))
                return false;
            _keysCombinations.Add(keysCombination);

            return true;

        }

        public bool Remove(Key key)
        {
            return _keys.Remove(key);
        }

        public void Undo()
        {
            try
            {
                _actionsToUndo.Pop()();
            }
            catch { }
        }
    }
}
