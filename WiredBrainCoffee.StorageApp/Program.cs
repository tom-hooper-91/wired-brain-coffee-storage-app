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

            Console.WriteLine("-----");

            GetEmployeeById(employeeRepository);

            Console.WriteLine("-----");

            WriteAllToConsole(employeeRepository);

            Console.WriteLine("-----");

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void WriteAllToConsole(IRepository<Employee> employeeRepository)
        {
            var items = employeeRepository.GetAll();

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
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "Globomantics" });
            organizationRepository.Save();
        }
    }
}
