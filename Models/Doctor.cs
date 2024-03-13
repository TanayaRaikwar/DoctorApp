using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId {get; set;}
        [Required(ErrorMessage = "Doctor name is required")]
        [StringLength(25, ErrorMessage = "Doctor name must be at most 25 characters")]
        public string DoctorName {get; set;}
    }
}