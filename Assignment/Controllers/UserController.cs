using Microsoft.AspNetCore.Mvc;
using Assignment.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NewProject.Controllers
{
    public class UserController : Controller
    {

        private static List<UserModel> userModels = new List<UserModel>();
        private static int submitCount = 0;


        public IActionResult Index()
        {
            ViewBag.SubmitCount = submitCount;
            return View(userModels);
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model)
        {  
                userModels.Add(model);
                submitCount++; 
                return RedirectToAction("Index");
        }


    }
}
