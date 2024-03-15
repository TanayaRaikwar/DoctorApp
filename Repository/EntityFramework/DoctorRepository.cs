using DoctorApp.Database;
using DoctorApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
            // Update the properties of the existing doctor with the new values
            _context.Entry(doctor).State = EntityState.Modified;
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
            return _context.DoctorSpecializations
            .Include(doc => doc.Doctor).Include(doc=> doc.Specialization)
            .ToList();
        }
        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            return _context.Surgeries
            .Include(surgery => surgery.Doctor)
            .ToList();
        }

        public Surgery AddSurgery(Surgery surgery)
        {
            _context.Surgeries.Add(surgery);
            _context.SaveChanges();
            return surgery;
        }

        public Surgery UpdateSurgery(Surgery surgery)
        {
            // Update the properties of the existing doctor with the new values
            _context.Entry(surgery).State = EntityState.Modified;
            _context.Surgeries.Update(surgery);
            _context.SaveChanges();
            return surgery;
        }

        public Surgery DeleteSurgery(int id)
        {
            var surgeryToBeDeleted = _context.Surgeries.Find(id);

            if (surgeryToBeDeleted == null)
            {
                return null;
            }
            _context.Surgeries.Remove(surgeryToBeDeleted);
            _context.SaveChanges();

            return surgeryToBeDeleted;
        }

        public Specialization AddSpecialization(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            _context.SaveChanges();
            return specialization;
        }

        public Specialization UpdateSpecialization(Specialization specialization)
        {
            // Update the properties of the existing doctor with the new values
            _context.Entry(specialization).State = EntityState.Modified;

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