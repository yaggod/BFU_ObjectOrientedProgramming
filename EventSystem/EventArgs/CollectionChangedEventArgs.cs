using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem.EventArgs
{
    internal class CollectionChangedEventArgs<T> : System.EventArgs
    {
        public enum CollectiongChangedType
        {
            RemovedElement,
            AddedElement
        };

        public readonly CollectiongChangedType Type;
        public readonly T Item;

        public CollectionChangedEventArgs(CollectiongChangedType type, T item)
        {
            Type = type;
            Item = item;
        }

    }
}