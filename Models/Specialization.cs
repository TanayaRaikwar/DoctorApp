using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationCode { get; set; }
        [Required(ErrorMessage = "Doctor name is required")]
        [StringLength(20, ErrorMessage = "Specialization name must be at most 20 characters")]
        public string SpecializationName { get; set; }
    }
}