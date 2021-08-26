namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization : EntityBase
    {
        //properties
        public string? Name { get; set; }

        //methods
        public override string ToString() => $"Id: {Id} Name: {Name}";
    }
}
