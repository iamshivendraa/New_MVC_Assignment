using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }     
        public double Salary {  get; set; }
        public string Department {  get; set; }

    }
}
