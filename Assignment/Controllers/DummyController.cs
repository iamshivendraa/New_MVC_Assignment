using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models.DummyModel;

namespace NewProject.Controllers
{
    public class DummyController : Controller
    {
        private static List<DummyModel> dummyModel = new List<DummyModel>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitForm(DummyModel model)
        {
            if(ModelState.IsValid)
            {
                dummyModel.Add(model);
                TempData["SuccessMessage"] = "Details added successfully!";
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
