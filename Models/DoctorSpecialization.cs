using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorApp.Models
{
    public class DoctorSpecialization
    {
        public int DoctorId {get; set;}
        public int SpecializationCode {get; set;}
        public DateOnly SpecializationDate {get; set;}
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("SpecializationCode")]
        public Specialization Specialization { get; set; }
    }
}