using DoctorApp.DTO;
using DoctorApp.Models;
using DoctorApp.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DoctorApp.Database;
using DoctorApp.Services;

namespace DoctorApp.Controllers
{
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private MyContext _context;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper,IDoctorService doctorService, MyContext context)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorService;
            _mapper = mapper;
            _context = context;

        }
        [HttpPost]
        public IActionResult Add(DoctorRequestDto doctorRequestDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorRequestDto);

            var newDoctor = _doctorRepository.AddDoctor(doctor);
            if (newDoctor == null)
                return BadRequest("Some issue while adding");

            return Ok(newDoctor);
        }
        [HttpPut]
        public IActionResult Update(Doctor doctor)
        {
            var student = _mapper.Map<Doctor>(doctor);
            var updatedDoctor = _doctorRepository.UpdateDoctor(doctor);
            if (updatedDoctor != null)
                return Ok(updatedDoctor);

           return BadRequest("Unable to update student");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedDoctor = _context.Doctors.Find(id);
            if (deletedDoctor != null)
            {
                _doctorRepository.DeleteDoctor(id);
                return Ok(deletedDoctor);
            }
            return NotFound();


        }
        [HttpPost]
        public IActionResult AddSpecialization(SpecializationRequestDto specializationRequestDto)
        {
            var specialization = _mapper.Map<Specialization>(specializationRequestDto);

            var newSpecialization = _doctorRepository.AddSpecialization(specialization);
            if (newSpecialization == null)
                return BadRequest("Some issue while adding");

            return Ok(newSpecialization);
        }
        [HttpPut]
        public IActionResult UpdateSpecialization(Specialization specialization)
        {
            var existingSpecialization = _mapper.Map<Specialization>(specialization);
            var updatedSpecialization = _doctorRepository.UpdateSpecialization(existingSpecialization);
            if (updatedSpecialization != null)
                return Ok(updatedSpecialization);

           return BadRequest("Unable to update specialization");
        }
        [HttpDelete]
        public IActionResult DeleteSpecialization(int id)
        {
            var deletedSpecialization = _context.Specializations.Find(id);
            if (deletedSpecialization != null)
            {
                _doctorRepository.DeleteSpecialization(id);
                return Ok(deletedSpecialization);
            }
            return NotFound();


        }
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }
        [HttpGet]
        public IActionResult GetAllSpecialization()
        {
            var specializations = _doctorService.GetAllSpecializations();
            return Ok(specializations);
        }


    }
}
