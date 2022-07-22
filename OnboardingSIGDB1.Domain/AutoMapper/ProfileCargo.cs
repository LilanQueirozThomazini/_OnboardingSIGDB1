using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class ProfileCargo: Profile
    {
        public ProfileCargo()
        {
            CreateMap<Cargo, CargoDTO>().ReverseMap();
        }
    }
}
