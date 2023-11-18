using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.EventArgs
{
    internal class PropertyChangedEventArgs<T> : System.EventArgs
    {
        public readonly T Item;

        public PropertyChangedEventArgs(T item)
        {
            Item = item;
        }
    }
}
