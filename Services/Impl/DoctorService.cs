using DoctorApp.Models;
using DoctorApp.Repository;

namespace DoctorApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public bool AddDoctor(Doctor doctor)
        {
            return _doctorRepository.AddDoctor(doctor);
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.UpdateDoctor(doctor);
        }
        public Doctor DeleteDoctor(int id)
        {
            return _doctorRepository.DeleteDoctor(id);
        }

        public List<DoctorSpecialization> GetDoctorsBySpecialization()
        {
            return _doctorRepository.GetDoctorsBySpecialization();
        }
        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            return _doctorRepository.GetAllSurgeryTypeForToday();
        }

        public Surgery AddSurgery(Surgery surgery)
        {
            return _doctorRepository.AddSurgery(surgery);
        }
        public Surgery UpdateSurgery(Surgery surgery)
        {
            return _doctorRepository.UpdateSurgery(surgery);
        }
        public Surgery DeleteSurgery(int id)
        {
            return _doctorRepository.DeleteSurgery(id);
        }
        public Specialization AddSpecialization(Specialization specialization)
        {
            return _doctorRepository.AddSpecialization(specialization);
        }

        public Specialization UpdateSpecialization(Specialization specialization)
        {
            return _doctorRepository.UpdateSpecialization(specialization);
        }

        public Specialization DeleteSpecialization(int id)
        {
            return _doctorRepository.DeleteSpecialization(id);
        }
        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }
        public List<Specialization> GetAllSpecializations()
        {
            return _doctorRepository.GetAllSpecializations();
        }
        
    }
}