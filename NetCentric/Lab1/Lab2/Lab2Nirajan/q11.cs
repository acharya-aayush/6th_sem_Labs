using System;
using System.IO;
using System.Linq;

namespace Lab2Nirajan
{
    // Question 11: Employee with LINQ
    class Employee
    {
        public int ID;
        public string Name, Address;
        public double Salary;
        public static void Run()
        {
            Employee[] emps = new Employee[3]
            {
                new Employee{ID=1, Name="Ram", Address="KTM", Salary=45000},
                new Employee{ID=2, Name="Shyam", Address="PKR", Salary=35000},
                new Employee{ID=3, Name="Gita", Address="BKT", Salary=50000}
            };
            var filtered = emps.Where(e => e.Salary > 40000);
            foreach (var e in filtered)
                Console.WriteLine($"ID: {e.ID}, Name: {e.Name}, Salary: {e.Salary}");
        }
    }

    internal class q11
    {
        public static void Run()
        {
            Employee.Run();
        }
    }
}
