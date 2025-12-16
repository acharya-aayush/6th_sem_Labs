using Lab6.Models;

namespace Lab6.Services
{
    public interface IEmpRepo
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee emp);
        void Update(Employee emp);
        void Delete(int id);
    }
}