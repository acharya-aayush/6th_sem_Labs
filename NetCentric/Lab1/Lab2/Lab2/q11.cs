using System;
using System.Linq;

namespace Lab2
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        
        public Employee(int id, string name, string addr, decimal sal) 
        { ID = id; Name = name; Address = addr; Salary = sal; }
        
        public override string ToString() => $"{ID}: {Name}, {Address}, {Salary:C}";
    }

    class ImainEmployee
    {
        public static void main()
        {
            var employees = new[]
            {
                new Employee(1, "John", "Main St", 35000),
                new Employee(2, "Jane", "Oak Ave", 45000),
                new Employee(3, "Bob", "Pine Rd", 55000),
                new Employee(4, "Alice", "Elm St", 38000),
                new Employee(5, "Charlie", "Maple Dr", 42000)
            };

            Console.WriteLine("Employees with salary > 40000:");
            var high = from e in employees where e.Salary > 40000 select e;
            foreach (var emp in high) Console.WriteLine(emp);
        }
    }

    internal class q11
    {
        public static void Run()
        {
            Console.WriteLine("=== Question 11: Employee LINQ ===");
            ImainEmployee.main();
            Console.WriteLine();
        }
    }
}
