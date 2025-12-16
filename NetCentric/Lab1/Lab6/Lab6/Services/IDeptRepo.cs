using Lab6.Models;

namespace Lab6.Services
{
    public interface IDeptRepo
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Add(Department dept);
        void Update(Department dept);
        void Delete(int id);
    }
}