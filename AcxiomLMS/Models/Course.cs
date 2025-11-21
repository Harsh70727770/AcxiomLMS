using System.ComponentModel.DataAnnotations;

namespace AcxiomLMS.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Instructor Name")]
        public string Instructor { get; set; }
    }
}
