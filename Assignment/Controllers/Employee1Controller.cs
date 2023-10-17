using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class Employee1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Employee1Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var empDetails =new EmployeeViewModel();
            return View(empDetails);
        }

        public JsonResult GetName()
        {
            var empList = _context.Employees.ToList();
            return Json(empList);
        }

        [HttpGet]
        public JsonResult ModalDetails(int id) {
            var modalDetails = _context.Employees.Find(id);
            return Json(modalDetails);
        }
    }
}
