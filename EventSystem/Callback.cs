using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem
{
    internal class Callback<E> where E : System.EventArgs
    {
        private readonly List<Action<object, E>> _actions = new();

        public Callback()
        {

        }

        public void Invoke(object sender, E eventArgs)
        {
            foreach (var action in _actions)
            {
                action?.Invoke(sender, eventArgs);
            }
        }

        public void Add(Action<object, E> action)
        {
            _actions.Add(action);
        }

        public bool Remove(Action <object, E> action)
        {
            return _actions.Remove(action);
        }
    }
}
