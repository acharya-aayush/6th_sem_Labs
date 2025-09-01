using Lab3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Lab3.Controllers
{
    public class employeeController : Controller
    {
        // Simulating employee data
        private static List<employee> employees = new List<employee>
        {
            new employee { Id = 1, Name = "Nirajan Kumar Yadav", departmentID = 101 },
            new employee { Id = 2, Name = "Nilisha Shakya", departmentID = 102 },
            new employee { Id = 3, Name = "Nischal Gyawali", departmentID = 101 },
            new employee { Id = 4, Name = "Sumit Kumar Shah", departmentID = 103 }
        };

        // Simulating department data (same as in DepartmentController)
        private static List<Department> departments = new List<Department>
        {
            new Department { Id = 101, Name = "Information Technology" },
            new Department { Id = 102, Name = "Human Resources" },
            new Department { Id = 103, Name = "Graphics" }
        };

        // Display all employees
        public ActionResult Index()
        {
            return View(employees);
        }

        // Display one employee by ID
        public ActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return HttpNotFound();

            // Get department name for display
            var dept = departments.FirstOrDefault(d => d.Id == emp.departmentID);
            ViewBag.DepartmentName = dept?.Name ?? "Unknown Department";

            return View(emp);
        }

        // Helper method to get department name
        private string GetDepartmentName(int departmentId)
        {
            var dept = departments.FirstOrDefault(d => d.Id == departmentId);
            return dept?.Name ?? "Unknown Department";
        }
    }
}
