using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int YearsAtWork { get; set; }
    }
    internal class Program
    {
        public static List<Employee> employeesBySalary(Dictionary<string, List<Employee>> workers, string department)
        {
            if (workers.ContainsKey(department))
            {
                return workers[department].Where(b => b.Salary > 2000).ToList();
            }
            else
            {
                Console.WriteLine($"There is no {department} in company");
                return new List<Employee>();
            }
        }
        public static List<Employee> employeesByYearsAtWork(Dictionary<string, List<Employee>> workers, int years)
        {
            var allEmployees = workers.Values.SelectMany(w => w).ToList();
            return allEmployees.Where(e => e.YearsAtWork > years).ToList();
        }

        public static void countEmployees(Dictionary<string, List<Employee>> workers)
        {
            var groupedByParameter = workers.Select(b => new
            {
                Department = b.Key,
                EmployeesCount = b.Value.Count()
            }).ToList();
            foreach (var employee in groupedByParameter)
            {
                Console.WriteLine($"{employee.Department}: {employee.EmployeesCount} employees");
            }

        }
        static void Main(string[] args)
        {
            Dictionary<string, List<Employee>> workers = new Dictionary<string, List<Employee>>
            {
                {"HR", new List<Employee>
                    {
                        new Employee{Id = 10, Name = "George", Salary = 2000, YearsAtWork = 2},
                        new Employee{Id = 11, Name = "Marta", Salary = 4000, YearsAtWork =3},
                        new Employee{Id = 12, Name = "Alboniy", Salary = 13000, YearsAtWork = 6}
                    }
                },
                {"IT", new List<Employee>
                    {
                        new Employee{Id = 13, Name = "Max", Salary = 12000, YearsAtWork = 4},
                        new Employee{Id = 14, Name = "Mitro", Salary = 24000, YearsAtWork = 9},
                        new Employee{Id = 15, Name = "Orban", Salary = 513000, YearsAtWork = 20}
                    }
                },
                {"Finance", new List<Employee>
                    {
                        new Employee{Id = 16, Name = "Nazar", Salary = 1000, YearsAtWork = 1},
                        new Employee{Id = 17, Name = "Nikita", Salary = 500, YearsAtWork = 0},
                        new Employee{Id = 18, Name = "Michal", Salary = 17000, YearsAtWork = 6}
                    }
                }
            };

            var sortedEmployees = employeesBySalary(workers, "Finance");
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"Id: {employee.Id} Name: {employee.Name} Salary: {employee.Salary}" +
                    $"Years at work: {employee.YearsAtWork}");
            }

            Console.WriteLine("--------------------");

            var employeesByYears = employeesByYearsAtWork(workers, 5);
            foreach (var employee in employeesByYears)
            {
                Console.WriteLine($"Id: {employee.Id} Name: {employee.Name} Salary: {employee.Salary}" +
                    $"Years at work: {employee.YearsAtWork}");
            }

            Console.WriteLine("-----------------------");
            countEmployees(workers);
            Console.ReadLine();
        }
    }
}
