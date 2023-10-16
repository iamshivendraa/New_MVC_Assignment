using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewProject.Models;
using NuGet.Versioning;
using System.Linq;

namespace NewProject.Controllers
{
    public class CityController : Controller
    {

        public IActionResult Index()
        {
            var cityViewModel = new CityViewModel();
            return View(cityViewModel);

        }
        [HttpPost]
        public IActionResult SelectedCity(CityViewModel model)
        { 
            if (ModelState.IsValid) {
                int selectedCityId = model.SelectedCityId;
                CityModel selectedCity = model.Cities().FirstOrDefault(city => city.Id == selectedCityId);
                return View("SelectedCity", selectedCity);
            }
            return View("Index",model);
                                
        }
    }
}
