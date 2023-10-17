using System.ComponentModel.DataAnnotations;

namespace NewProject.Models.DummyModel
{
    public class DummyModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
