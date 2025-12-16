using Lab6.Models;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDeptRepo _deptRepo;

        public DeptController(IDeptRepo deptRepo)
        {
            _deptRepo = deptRepo;
        }

        public IActionResult Index()
        {
            var depts = _deptRepo.GetAll();
            return View(depts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            _deptRepo.Add(dept);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var dept = _deptRepo.GetById(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            _deptRepo.Update(dept);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _deptRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}