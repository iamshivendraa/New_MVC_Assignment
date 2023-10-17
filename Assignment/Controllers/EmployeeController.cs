using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var empView = new EmployeeViewModel();
            return View(empView);
        }
        public IActionResult EmployeeDetails()
        {
            var empList = _context.Employees.FromSqlRaw<EmployeeViewModel>("EmpDetails").ToList();
            
            return View(empList);
        }

        [HttpPost]

        public IActionResult EmployeeDetails(EmployeeViewModel model)
        {
            int selectedCityId = model.CityId;
            CityModel selectedCity = model.EmployeeCity().FirstOrDefault(city => city.Id == selectedCityId);          
            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("EmployeeDetails",_context.Employees.ToList());
            }
            return View("Index", model);
        }

    }
}
