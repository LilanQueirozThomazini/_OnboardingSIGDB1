using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ConsultaFuncionario : IConsultaFuncionario
    {
        private readonly IFuncionarioRepository _repository;

        public ConsultaFuncionario(IFuncionarioRepository funcionarioRepository)
        {
            _repository = funcionarioRepository;
        }

        public bool VerificarExisteEmpresaVinculada(int empresaId)
        {
            return _repository.GetAll(x => x.EmpresaId == empresaId).Any();
        }
    }
}
