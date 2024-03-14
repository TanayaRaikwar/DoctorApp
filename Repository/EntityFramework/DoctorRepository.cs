using DoctorApp.Database;
using DoctorApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DoctorApp.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private MyContext _context;

        public DoctorRepository(MyContext context)
        {
            _context = context;
        }
        public bool AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return true;
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
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
        public List<DoctorSpecialization> GetDoctorsBySpecialization()
        {
            return _context.DoctorSpecializations.ToList();
        }
        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            return _context.Surgeries.ToList();
        }

        public Surgery AddSurgery(Surgery surgery)
        {
            _context.Surgeries.Add(surgery);
            _context.SaveChanges();
            return surgery;
        }

        public Surgery UpdateSurgery(Surgery surgery) 
        {
            _context.Surgeries.Update(surgery);
            _context.SaveChanges();
            return surgery;
        }
        public Specialization AddSpecialization(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            _context.SaveChanges();
            return specialization;
        }

        public Specialization UpdateSpecialization(Specialization specialization)
        {
            _context.Specializations.Update(specialization);
            _context.SaveChanges();
            return specialization;
        }

        public Specialization DeleteSpecialization(int id)
        {
            var specializationToBeDeleted = _context.Specializations.Find(id);

            if (specializationToBeDeleted == null)
            {
                return null;
            }
            _context.Specializations.Remove(specializationToBeDeleted);
            _context.SaveChanges();

            return specializationToBeDeleted;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public List<Specialization> GetAllSpecializations()
        {
            return _context.Specializations.ToList();
        }
    }
}