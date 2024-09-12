using System.ComponentModel.DataAnnotations;

namespace ECC_API.Models
{
    public class Students
    {

        //declare variables 
        [Key]
        public int StudentNum { get; set; }  // Primary Key
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
