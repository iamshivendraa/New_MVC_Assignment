using System.ComponentModel.DataAnnotations;

namespace NewProject.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Student's name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Student's class is required.")]
        public int Class { get; set; }
        [Required(ErrorMessage = "Student's city is required.")]
        public string City {  get; set; }

        [Required(ErrorMessage = "Student's marks are required.")]
        public int Marks {  get; set; }

    }
}
