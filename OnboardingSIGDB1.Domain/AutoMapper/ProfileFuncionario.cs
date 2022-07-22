using AutoMapper;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.AutoMapper
{
    public class ProfileFuncionario : Profile
    {
        public ProfileFuncionario()
        {
            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(x => x.Cpf, o => o.MapFrom(x => Convert.ToUInt64(x.Cpf).ToString(@"000\.000\.000\-00")));
            CreateMap<FuncionarioDTO, Funcionario>()
                .ForMember(x => x.Cpf, o => o.MapFrom(x => Regex.Replace(x.Cpf, @"[-,.]", string.Empty)));
            CreateMap<Funcionario, FuncionarioConsultaDTO>()
                .ForMember(x => x.CargoId, opt => {
                    opt.PreCondition(x => x.Count() > 0);
                    opt.MapFrom(x => x.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().CargoId);
                })
                .ForMember(x => x.CargoDescricao, opt => {
                    opt.PreCondition(x => x.Count() > 0);
                    opt.MapFrom(x => x.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().Cargo.Descricao);
                })
                .ForMember(x => x.DataVinculo, opt => {
                    opt.PreCondition(x => x.Count() > 0);
                    opt.MapFrom(x => x.FuncionarioCargo.OrderByDescending(x => x.DataVinculo).FirstOrDefault().DataVinculo);
                })
                .ForMember(x => x.EmpresaNome, opt => opt.MapFrom(f => f.Empresa.Nome))
                .ForMember(x => x.Cpf, o => o.MapFrom(x => Convert.ToUInt64(x.Cpf).ToString(@"000\.000\.000\-00")));
        }
    }
}
