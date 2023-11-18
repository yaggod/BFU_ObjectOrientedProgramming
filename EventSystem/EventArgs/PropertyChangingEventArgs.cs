using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.EventArgs
{
    internal class PropertyChangingEventArgs<T> : System.EventArgs
    {
        public readonly T Item;
        public bool ShouldChange
        {
            get;
            set;
        } = true;

        public PropertyChangingEventArgs(T item)
        {
            Item = item;
        }
    }
}
