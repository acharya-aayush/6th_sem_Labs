using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new()
        {
            new() { Id = 1, Name = "Aayush Acharya", Email = "aayush@gmail.com", Position = "Developer", Age = 20, Salary = 65000 },
            new() { Id = 5, Name = "Shiksha Karki", Email = "shiksha@gmail.com", Position = "Marketing", Age = 20, Salary = 55000 }
        };
        static int nextId = 6;

        public IActionResult Index() => View(employees);
        public IActionResult Create() => View();
        [HttpPost] public IActionResult Create(Employee e) { e.Id = nextId++; employees.Add(e); return RedirectToAction("Index"); }
        public IActionResult Edit(int id) => View(employees.Find(e => e.Id == id));
        [HttpPost] public IActionResult Edit(Employee e) { var old = employees.Find(x => x.Id == e.Id); if(old != null) { old.Name = e.Name; old.Email = e.Email; old.Position = e.Position; old.Age = e.Age; old.Salary = e.Salary; } return RedirectToAction("Index"); }
        [HttpPost] public IActionResult Delete(int id) { employees.RemoveAll(e => e.Id == id); return RedirectToAction("Index"); }
    }
}