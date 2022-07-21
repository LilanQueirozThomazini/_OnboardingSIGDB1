using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain //TODO CONVERSAR .Interfaces.Funcionario
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IList<FuncionarioConsultaDTO> GetAllFuncionarios();

        FuncionarioConsultaDTO GetFuncionario(int id);
    }
}
