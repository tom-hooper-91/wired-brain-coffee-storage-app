namespace WiredBrainCoffee.StorageApp.Repositories
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)// this keyword makes method an extension of the IWriteRepository
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
