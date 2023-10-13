using Assignment.Data;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudents()
        {
            var students = _context.Students.ToList();
            return Json(students);
        }
        [HttpPost]
        public JsonResult Insert(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(model);
                _context.SaveChanges();
                return Json("Student record added successfully!");
            }
            return Json("Model Validation Failed!");
        }
        [HttpGet]
        public JsonResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            return Json(student);
        }
        [HttpPost]
        public JsonResult Edit(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(model);
                _context.SaveChanges();
                return Json("Product details updated.");
            }
            return Json("Model validation failed");
        }
    }
}
