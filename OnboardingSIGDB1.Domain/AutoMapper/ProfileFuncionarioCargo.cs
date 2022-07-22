using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class ProfileFuncionarioCargo : Profile
    {
        public ProfileFuncionarioCargo()
        {
            CreateMap<FuncionarioCargo, FuncionarioCargoDTO>().ReverseMap();
        }
    }
}
