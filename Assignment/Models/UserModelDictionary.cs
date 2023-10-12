using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Assignment.Models
{
    public class UserModelDictionary
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age {  get; set; }
    }
}
