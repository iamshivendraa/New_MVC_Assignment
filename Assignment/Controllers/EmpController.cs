using Assignment.Data;
using Hangfire.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class EmpController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmpController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var empList = _context.Employees.ToList();
            return View(empList);
        }

        public IActionResult Details(int id)
        {
            var empDetails = _context.Employees.Find(id);
            return View(empDetails);
        }
    }
}
