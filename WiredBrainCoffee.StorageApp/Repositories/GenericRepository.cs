using System;
using System.Collections.Generic;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class GenericRepository<T>
    {
        protected readonly List<T> _items = new ();// shorthand for new List<Employee>()

        //methods 
        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryWithRemove<T> : GenericRepository<T>
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}
