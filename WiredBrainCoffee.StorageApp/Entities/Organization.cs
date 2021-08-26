namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization
    {
        //properties
        public int Id { get; set; }
        public string? Name { get; set; }

        //methods
        public override string ToString() => $"Id: {Id} Name: {Name}";
    }
}
