using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorApp.Models
{
    public class DoctorSpecialization
    {
        [ForeignKey("Doctor")]
        public int DoctorId {get; set;}
        public Doctor Doctor { get; set; }

        [ForeignKey("Specialization")]
        public string SpecializationCode {get; set;}
        public Specialization Specialization { get; set; }

        [Required(ErrorMessage = "Specialization Date is required")]
        public DateOnly SpecializationDate {get; set;}
    }
}