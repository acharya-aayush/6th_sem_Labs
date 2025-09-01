using Lab5.Models;

namespace Lab5.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Aayush Acharya", Position = "Developer", Salary = 60000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Swornim Raj Dangol", Position = "Designer", Salary = 55000, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Nilima Shrestha", Position = "Manager", Salary = 75000, DepartmentId = 1 }
            };
        }

        public List<Employee> GetAll() => _employees;

        public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
                existing.DepartmentId = employee.DepartmentId;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
                _employees.Remove(employee);
        }
    }
}