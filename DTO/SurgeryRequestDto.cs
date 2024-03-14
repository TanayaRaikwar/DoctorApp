namespace DoctorApp.DTO
{
    public class SurgeryRequestDto
    {
        public int SurgeryId { get; set; }
        public int DoctorId { get; set; }
        public DateOnly SurgeryDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SurgeryCategory { get; set; }
    }
}