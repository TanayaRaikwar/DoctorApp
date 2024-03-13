using DoctorApp.Models;

namespace DoctorApp.Repository
{
    public interface IDoctorRepository
    {
        public string AddDoctor(Doctor doctor);
        public Doctor UpdateDoctor( Doctor doctor);
        public Doctor DeleteDoctor(int id );
    }
}