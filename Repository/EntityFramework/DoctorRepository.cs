using DoctorApp.Database;
using DoctorApp.Models;

namespace DoctorApp.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private  MyContext _context;

        public DoctorRepository(MyContext context)
        {
            _context = context;
        }
        public string AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor.DoctorName;
        }
        public Doctor UpdateDoctor(Doctor doctor) 
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges ();
            return doctor;
        }
        public Doctor DeleteDoctor(int id)
        {
            var doctorToBeDeleted = _context.Doctors.Find(id);

            if (doctorToBeDeleted == null)
            {
                return null; 
            }
            _context.Doctors.Remove(doctorToBeDeleted);
            _context.SaveChanges();
            
            return doctorToBeDeleted;
        }

        
    }
}