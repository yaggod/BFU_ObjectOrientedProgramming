using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualKeyboard.Keyboard
{
    internal class Keyboard
    {
        public Dictionary<string, Key> Keys
        { 
            get;
            private set; 
        }

        public List<KeysCombination> _keysCombinations;

        private List<Action> _actionsToUndo;

        public Keyboard()
        {
            Keys = new Dictionary<string, Key>();
            _keysCombinations = new List<KeysCombination>();
            _actionsToUndo = new List<Action>();

        }

        public void AddKey(Key key)
        {
            if(!Keys.ContainsKey(key.KeyName))
            {
                Keys.Add(key.KeyName, key);
                key.OnKeyPressed += (sender, _) => ConsoleHelper.WriteLine(key.KeyName);
                key.OnKeyPressed += (sender, _) => ConsoleHelper.WriteLogsLine("Pressed " + key.KeyName);
                key.OnKeyPressed += (sender, _) => HandleKeysCombinations();
                key.OnKeyPressed += (sender, _) => _actionsToUndo.Add(() => ConsoleHelper.Undo());


                key.OnKeyReleased += (sender, _) => ConsoleHelper.WriteLogsLine("Released " + key.KeyName);
            }
            else
            {
                throw new InvalidOperationException($"Key {key.KeyName} already been added");
            }
        }

        public void AddKeysCombination(KeysCombination combination)
        {
            ConsoleHelper.WriteLogsLine($"Registered {combination.FirstKey.KeyName}+{combination.SecondKey.KeyName} combination");
            _keysCombinations.Add(combination);
        }


        public void PressKey(string keyName)
        {
            PressKey(Keys[keyName]);
        }
        public void PressKey(Key key)
        {
            if(Keys.ContainsValue(key))
            {
                key.Press();
            }
            else
            {
                throw new InvalidOperationException($"There is no {key.KeyName} key in the keyboard");
            }
        }
        public void ReleaseKey(string keyName)
        {
            ReleaseKey(Keys[keyName]);
        }
        public void ReleaseKey(Key key)
        {
            if (Keys.ContainsValue(key))
            {
                key.Release();
            }
            else
            {
                throw new InvalidOperationException($"There is no {key.KeyName} key in the keyboard");
            }
        }

        public void Undo()
        {
            if(_actionsToUndo.Count > 0)
            {
                _actionsToUndo.Last().Invoke();
                _actionsToUndo.RemoveAt(_actionsToUndo.Count - 1);
                ConsoleHelper.WriteLogsLine("User canceled his last action");
            }
        }


        private void HandleKeysCombinations()
        {
            foreach(var keysCombinations in _keysCombinations)
            {
                if(keysCombinations.AreBothPressed)
                {
                    keysCombinations.Action();
                    _actionsToUndo.Add(keysCombinations.ActionToUndo);
                }
            }
        }

   
    
    }

}
 