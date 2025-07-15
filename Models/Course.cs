using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [StringLength(50)]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Fees are required.")]
        [Range(0, 100000, ErrorMessage = "Please enter valid course fees.")]
        public decimal Fees { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
