using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public delegate void ItemAdded(object item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly ItemAdded? itemAddedCallback;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallback = null)
        {
            _dbContext = dbContext;
            this.itemAddedCallback = itemAddedCallback;
            _dbSet = dbContext.Set<T>();
        }

        //methods
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();//returns a copy rather than the original data
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            itemAddedCallback?.Invoke(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }

}
