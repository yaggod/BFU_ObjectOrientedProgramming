using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.Interfaces
{
    internal interface INotifyElementChange<T, E> where E : System.EventArgs
    {
        protected Callback<E> Callback
        {
            get;
        }

        public void AddHandler(Action<object, E> action);
        public bool RemoveHandler(Action<object, E> action);

    }
}
