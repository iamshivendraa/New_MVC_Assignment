using Assignment.Data;
using Microsoft.AspNetCore.Mvc;

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
            var empList = _context.Employees.ToList();
            return View(empList);
        }
    }
}
