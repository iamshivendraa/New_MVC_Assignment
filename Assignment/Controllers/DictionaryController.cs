using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
    public class DictionaryController : Controller
    {
        private static Dictionary<int, UserModelDictionary> userInfo = new Dictionary<int, UserModelDictionary>();
        private static int submitCount = 0;
        public IActionResult Index()
        {
            ViewBag.SubmitCount = submitCount;
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model, string name, int age)
        {
            int key = userInfo.Count + 1;
            UserModelDictionary user = new UserModelDictionary
            { Name = name, Age = age };
            userInfo.Add(key, user);
            submitCount++;
            return RedirectToAction("Index");
        }
    }
}
