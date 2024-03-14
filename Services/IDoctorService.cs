using DoctorApp.Models;

namespace DoctorApp.Services
{
    public interface IDoctorService
    {
        public bool AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor(Doctor doctor);
        public Doctor DeleteDoctor(int id);
        public Specialization AddSpecialization(Specialization specialization);
        public Specialization UpdateSpecialization(Specialization specialization);
        public Specialization DeleteSpecialization(int id);
        public List<Doctor> GetAllDoctors();
        public List<Specialization> GetAllSpecializations();

    

    }
}