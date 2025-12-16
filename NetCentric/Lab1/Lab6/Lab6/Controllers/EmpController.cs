using Lab6.Models;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmpRepo _empRepo;

        public EmpController(IEmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public IActionResult Index()
        {
            var emps = _empRepo.GetAll();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _empRepo.Add(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _empRepo.GetById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _empRepo.Update(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _empRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}