using Lab5.Models;

namespace Lab5.Services
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department? GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}