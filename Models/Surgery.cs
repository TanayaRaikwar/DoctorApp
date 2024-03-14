using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorApp.Models
{
    public class Surgery
    {
        [Key]
        public int SurgeryId {get; set;}

        [ForeignKey("Doctor")]
        public int DoctorId {get; set;}
        public Doctor Doctor { get; set; }

        [Required(ErrorMessage = "Surgery date is required")]
        public DateOnly SurgeryDate {get; set;}

        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime {get; set;}

        [Required(ErrorMessage = "End time is required")]
        public DateTime EndTime {get; set;}

        [StringLength(3, ErrorMessage = "Surgery category must be at most 3 characters")]
        public string SurgeryCategory {get; set;}

    }
}