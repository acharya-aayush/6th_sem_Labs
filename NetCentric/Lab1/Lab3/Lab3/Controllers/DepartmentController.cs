using Lab3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class DepartmentController : Controller
    {
        // Simulating department data
        private static List<Department> departments = new List<Department>
        {
            new Department { Id = 101, Name = "Information Technology" },
            new Department { Id = 102, Name = "Human Resources" },
            new Department { Id = 103, Name = "Graphics" }
        };

        // Display all departments
        public ActionResult Index()
        {
            return View(departments);
        }

        // Display one department by ID
        public ActionResult Details(int id)
        {
            var dept = departments.FirstOrDefault(d => d.Id == id);
            if (dept == null)
                return HttpNotFound();

            return View(dept);
        }
    }
}