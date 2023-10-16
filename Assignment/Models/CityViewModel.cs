using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NewProject.Models
{
    public class CityViewModel
    {
        public int SelectedCityId { get; set; }
        public List<CityModel>Cities()
        {
            var city = new List<CityModel>();
            city.Add(new CityModel { Id = 1, Name = "Noida" });
            city.Add(new CityModel { Id = 2, Name = "Ghaziabad" });
            city.Add(new CityModel { Id = 3, Name = "Meerut" });
            city.Add(new CityModel { Id = 4, Name = "Agra" });
            city.Add(new CityModel { Id = 5, Name = "Mathura" });
            return city;

        }       
    }
}
