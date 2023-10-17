namespace NewProject.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CityId {  get; set; }
        public List<CityModel> EmployeeCity()
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
