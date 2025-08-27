using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class EmployeeController : Controller
    {
        // Static list to store employees (in a real app, this would be a database)
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Position = "Software Developer", Department = "IT", Salary = 65000, HireDate = new DateTime(2022, 1, 15) },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Position = "Project Manager", Department = "IT", Salary = 75000, HireDate = new DateTime(2021, 6, 20) },
            new Employee { Id = 3, FirstName = "Mike", LastName = "Johnson", Email = "mike.johnson@example.com", Position = "Business Analyst", Department = "Business", Salary = 60000, HireDate = new DateTime(2023, 3, 10) }
        };

        private static int _nextId = 4;

        // GET: Employee
        public IActionResult Index()
        {
            return View(_employees);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (_employees.Any(e => e.Email.Equals(employee.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Email", "An employee with this email already exists");
                    return View(employee);
                }

                employee.Id = _nextId++;
                _employees.Add(employee);
                TempData["SuccessMessage"] = "Employee added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                // Check if email already exists for another employee
                if (_employees.Any(e => e.Id != id && e.Email.Equals(employee.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Email", "An employee with this email already exists");
                    return View(employee);
                }

                // Update employee
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.Position = employee.Position;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.HireDate = employee.HireDate;

                TempData["SuccessMessage"] = "Employee updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}