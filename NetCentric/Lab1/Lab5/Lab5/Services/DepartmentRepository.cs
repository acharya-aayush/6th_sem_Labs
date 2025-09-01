using Lab5.Models;

namespace Lab5.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments;

        public DepartmentRepository()
        {
            _departments = new List<Department>
            {
                new Department { Id = 1, Name = "IT", Description = "Information Technology", Manager = "Aayush Acharya" },
                new Department { Id = 2, Name = "HR", Description = "Human Resources", Manager = "Nilima Shrestha" },
                new Department { Id = 3, Name = "Finance", Description = "Financial Management", Manager = "Aarjanmani Kandel" }
            };
        }

        public List<Department> GetAll() => _departments;

        public Department? GetById(int id) => _departments.FirstOrDefault(d => d.Id == id);

        public void Add(Department department)
        {
            department.Id = _departments.Count > 0 ? _departments.Max(d => d.Id) + 1 : 1;
            _departments.Add(department);
        }

        public void Update(Department department)
        {
            var existing = GetById(department.Id);
            if (existing != null)
            {
                existing.Name = department.Name;
                existing.Description = department.Description;
                existing.Manager = department.Manager;
            }
        }

        public void Delete(int id)
        {
            var department = GetById(id);
            if (department != null)
                _departments.Remove(department);
        }
    }
}