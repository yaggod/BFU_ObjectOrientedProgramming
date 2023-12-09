using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersRepository
{
    public class MemoryRepository<T> : IRepository<T>
    {
        protected readonly List<T> _items = new();

        public IEnumerable<T> Items => _items;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Delete(T item)
        {
            _items.Remove(item);
        }

        public void Update(T item)
        {
            // Do nothing since this class is not database-related
        }
    }
}
