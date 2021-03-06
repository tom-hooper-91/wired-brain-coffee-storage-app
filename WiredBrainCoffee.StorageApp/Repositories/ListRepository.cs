using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
          
        private readonly List<T> _items = new ();// shorthand for new List<T>()

        //methods
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();//returns a copy rather than the original data
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            //everything saved already in List<T>
        }

    }

}
