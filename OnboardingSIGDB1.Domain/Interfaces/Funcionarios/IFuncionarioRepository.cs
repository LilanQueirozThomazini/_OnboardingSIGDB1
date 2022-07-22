using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IList<FuncionarioConsultaDTO> GetAllFuncionarios();

        FuncionarioConsultaDTO GetFuncionario(int id);
    }
}
