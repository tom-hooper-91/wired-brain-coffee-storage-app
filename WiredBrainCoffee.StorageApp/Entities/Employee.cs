namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee
    {
        //properties
        public int Id { get; set; }
        public string? FirstName { get; set; }

        //methods
        public override string ToString() => $"Id: {Id} FirstName: {FirstName}";
    }
}
