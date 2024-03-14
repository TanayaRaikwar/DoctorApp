using DoctorApp.DTO;
using DoctorApp.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DoctorApp.Database;
using DoctorApp.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private MyContext _context;

        public DoctorController(IMapper mapper, IDoctorService doctorService, MyContext context)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _context = context;

        }

        [HttpGet("get-doctor")]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }


        [HttpPost("add-doctor")]
        public IActionResult Add(DoctorRequestDto doctorRequestDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorRequestDto);

            var newDoctor = _doctorService.AddDoctor(doctor);
            if (newDoctor == null)
                return BadRequest("Some issue while adding");

            return Ok(newDoctor);
        }

        [HttpPut("update-doctor")]
        public IActionResult Update(DoctorRequestDto doctorRequestDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorRequestDto);
            var existingDoctor = _context.Doctors.Find(doctor.DoctorId);
            if (existingDoctor == null)
                return NotFound("Doctor not found.");
            try
            {
                // Detach the existing doctor from the context
                _context.Entry(existingDoctor).State = EntityState.Detached;

                _doctorService.UpdateDoctor(doctor);

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to update doctor: " + ex.Message);
            }
        }

        [HttpDelete("delete-doctor/{id}")]
        public IActionResult Delete(int id)
        {
            var deletedDoctor = _context.Doctors.Find(id);
            if (deletedDoctor != null)
            {
                _doctorService.DeleteDoctor(id);
                return Ok(deletedDoctor);
            }
            return NotFound();


        }

        [HttpGet("get-specialization")]
        public IActionResult GetAllSpecialization()
        {
            var specializations = _doctorService.GetAllSpecializations();
            return Ok(specializations);
        }

        [HttpPost("add-specialization")]
        public IActionResult AddSpecialization(SpecializationRequestDto specializationRequestDto)
        {
            var specialization = _mapper.Map<Specialization>(specializationRequestDto);

            var newSpecialization = _doctorService.AddSpecialization(specialization);
            if (newSpecialization == null)
                return BadRequest("Some issue while adding");

            return Ok(newSpecialization);
        }

        [HttpPut("update-specialization")]
        public IActionResult UpdateSpecialization(SpecializationRequestDto specializationRequestDto)
        {
            var specialization = _mapper.Map<Specialization>(specializationRequestDto);
            var existingSpecialization = _context.Specializations.Find(specializationRequestDto.SpecializationCode);
            if (existingSpecialization == null)
                return NotFound("Specialization not found.");
           
            try
            {
                // Detach the existing doctor from the context
                _context.Entry(existingSpecialization).State = EntityState.Detached;
                _doctorService.UpdateSpecialization(specialization);
                return Ok(specialization);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to update specialization: " + ex.Message);
            }
        }

        [HttpDelete("delete-specialization/{id}")]
        public IActionResult DeleteSpecialization(int id)
        {
            var deletedSpecialization = _context.Specializations.Find(id);
            if (deletedSpecialization != null)
            {
                _doctorService.DeleteSpecialization(id);
                return Ok(deletedSpecialization);
            }
            return NotFound();


        }

        [HttpGet("get-doctors-by-specialization")]
        public IActionResult GetDoctorsBySpecialization()
        {
            var doctorsBySpecializations = _doctorService.GetDoctorsBySpecialization();
            return Ok(doctorsBySpecializations);
        }

        [HttpGet("get-surgery")]
        public IActionResult GetAllSurgery()
        {
            var surgeries = _doctorService.GetAllSurgeryTypeForToday();
            return Ok(surgeries);
        }

        [HttpPost("add-surgery")]
        public IActionResult AddSurgery(SurgeryRequestDto surgeryRequestDto)
        {
            var surgery = _mapper.Map<Surgery>(surgeryRequestDto);

            var newSurgery = _doctorService.AddSurgery(surgery);
            if (newSurgery == null)
                return BadRequest("Some issue occurred while adding surgery.");

            return Ok(newSurgery);
        }

        [HttpPut("update-surgery")]
        public IActionResult UpdateSurgery(SurgeryRequestDto surgeryRequestDto)
        {
           
            var surgery = _mapper.Map<Surgery>(surgeryRequestDto);
            var existingSurgery = _context.Surgeries.Find(surgeryRequestDto.SurgeryId);
            if (existingSurgery == null)
                return NotFound("Surgery not found.");
            try
            {
                // Detach the existing doctor from the context
                _context.Entry(existingSurgery).State = EntityState.Detached;
                _doctorService.UpdateSurgery(surgery);
                return Ok(surgery);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to update specialization: " + ex.Message);
            }
        }

        [HttpDelete("delete-surgery/{id}")]
        public IActionResult DeleteSurgery(int id)
        {
            var deletedSurgery = _context.Surgeries.Find(id);
            if (deletedSurgery == null)
                return NotFound("Surgery not found.");

            _doctorService.DeleteSurgery(id);

            return Ok(deletedSurgery);
        }


    }
}
