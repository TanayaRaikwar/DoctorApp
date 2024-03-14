
using AutoMapper;
using DoctorApp.DTO;
using DoctorApp.Models;

namespace Aurionpro.PaymentFramework.Vender.API.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorRequestDto>().ReverseMap();
            CreateMap<Surgery, SurgeryRequestDto>().ReverseMap();
            CreateMap<Specialization, SpecializationRequestDto>().ReverseMap();
        }

    }
}



