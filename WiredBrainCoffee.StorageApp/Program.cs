using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());

            AddEmployees(employeeRepository);

            AddManager(employeeRepository);

            Console.WriteLine("-----");

            GetEmployeeById(employeeRepository);

            Console.WriteLine("-----");

            WriteAllToConsole(employeeRepository);

            Console.WriteLine("-----");

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.WriteLine("-----");

            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void AddManager(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Sara" });
            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        { 
            var items = repository.GetAll();

            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with ID of 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Pluralsight" },
                new Organization { Name = "Globomantics" }
            };
            AddBatch(organizationRepository, organizations);
        }

        private static void AddBatch(IRepository<Organization> organizationRepository, Organization[] organizations)
        {
            foreach (var item in organizations)
            {
                organizationRepository.Add(item);
            };
                organizationRepository.Save();
        }
    }
}
