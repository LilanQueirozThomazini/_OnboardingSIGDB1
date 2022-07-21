using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class EmpresaAutoMapper : Profile
    {
        public EmpresaAutoMapper()
        {
            CreateMap<Empresa, EmpresaDTO>()
                            .ForMember(x => x.Cnpj, o => o.MapFrom(x => Convert.ToUInt64(x.Cnpj).ToString(@"00\.000\.000\/0000\-00")));
            CreateMap<EmpresaDTO, Empresa>()
                .ForMember(x => x.Cnpj, o => o.MapFrom(x => Regex.Replace(x.Cnpj, @"[-,.,/]", string.Empty)));
        }
    }
}
