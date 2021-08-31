using System.Collections.Generic;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public interface IWriteRepository<in T>//makes type parameter contravariant, this means the type can be more specific on the interface
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IReadRepository<out T>//makes type parameter covariant, this means the type can be less specific on the interface
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : IEntity
    { 
    }
}