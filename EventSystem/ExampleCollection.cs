using EventSystem.EventArgs;
using EventSystem.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSystem
{
    internal class ExampleCollection<T> : INotifyCollectionChanged<T>, IEnumerable<T>
    {

        private readonly List<T> _items = new();

        private Callback<CollectionChangedEventArgs<T>> Callback
        {
            get;
        } = new();

        Callback<CollectionChangedEventArgs<T>> INotifyElementChange<T, CollectionChangedEventArgs<T>>.Callback => Callback;

        public ExampleCollection()
        {
            
        }

        public void Add(T item)
        {
            _items.Add(item);
            CollectionChangedEventArgs<T> eventArgs = new(CollectionChangedEventArgs<T>.CollectiongChangedType.AddedElement, item);
            Callback.Invoke(this, eventArgs);
        }

        public bool Remove(T item)
        {
            bool isSuccessfull = _items.Remove(item);
            if(isSuccessfull)
            {
                CollectionChangedEventArgs<T> eventArgs = new(CollectionChangedEventArgs<T>.CollectiongChangedType.RemovedElement, item);
                Callback.Invoke(this, eventArgs);
            }
            return isSuccessfull;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void AddHandler(Action<object, CollectionChangedEventArgs<T>> action)
        {
            Callback.Add(action);
        }

        public bool RemoveHandler(Action<object, CollectionChangedEventArgs<T>> action)
        {
            return Callback.Remove(action);
        }

        void INotifyElementChange<T, CollectionChangedEventArgs<T>>.AddHandler(Action<object, CollectionChangedEventArgs<T>> action)
        {
            throw new NotImplementedException();
        }

        bool INotifyElementChange<T, CollectionChangedEventArgs<T>>.RemoveHandler(Action<object, CollectionChangedEventArgs<T>> action)
        {
            throw new NotImplementedException();
        }
    }
}
