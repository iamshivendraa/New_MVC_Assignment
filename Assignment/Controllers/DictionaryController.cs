using Assignment.Controllers;
using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DictionaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static Dictionary<int, UserModelDictionary> userInfo = new Dictionary<int, UserModelDictionary>();
        private static int submitCount = 0;
        public IActionResult Index()
        {
            var userList = _context.Users.ToList();
            ViewBag.SubmitCount = submitCount;
            return View(userList);
        }

        [HttpPost]
        public IActionResult AddUser(string name, int age)
        {
            int key = userInfo.Count + 1;
            UserModelDictionary user = new UserModelDictionary
            { Name = name, Age = age };
            userInfo.Add(key, user);
            _context.Users.Add(user);
            _context.SaveChanges();
            submitCount++;
            return RedirectToAction("Index");
        }
    }
}
