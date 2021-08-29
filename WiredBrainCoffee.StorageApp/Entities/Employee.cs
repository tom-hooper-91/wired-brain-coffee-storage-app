namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee : EntityBase
    {
        //constructors
        //properties
        public string? FirstName { get; set; }

        //methods
        public override string ToString() => $"Id: {Id} FirstName: {FirstName}";
    }
}
