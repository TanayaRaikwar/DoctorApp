using DoctorApp.Models;

namespace DoctorApp.Repository
{
    public interface IDoctorRepository
    {
        public bool AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor( Doctor doctor);
        public Doctor DeleteDoctor(int id );
        public List<Doctor> GetAllDoctors();
        public Specialization AddSpecialization(Specialization specialization);
        public Specialization UpdateSpecialization(Specialization specialization);
        public Specialization DeleteSpecialization(int id);
        public List<Specialization> GetAllSpecializations();
        
    }
}