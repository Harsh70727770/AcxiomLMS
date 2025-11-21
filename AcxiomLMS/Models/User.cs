using System.ComponentModel.DataAnnotations;

namespace AcxiomLMS.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }     // Demo only – real app me hash karna

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }         // "Admin", "Student", "Teacher"
    }
}
