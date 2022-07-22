using AutoMapper.QueryableExtensions;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System.Collections.Generic;
using System.Linq;

namespace OnboardingSIGDB1.Data.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(DataContext dataContext) : base(dataContext) { }

        public IList<FuncionarioConsultaDTO> GetAllFuncionarios()
        {
            return _dbSet.ProjectTo<FuncionarioConsultaDTO>().ToList();
        }

        public FuncionarioConsultaDTO GetFuncionario(int id)
        {
            return _dbSet.Where(f => f.Id == id).ProjectTo<FuncionarioConsultaDTO>().FirstOrDefault();
        }
    }
}
