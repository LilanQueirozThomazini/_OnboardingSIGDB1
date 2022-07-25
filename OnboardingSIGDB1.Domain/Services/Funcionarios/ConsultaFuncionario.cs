using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ConsultaFuncionario : IConsultaFuncionario
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ConsultaFuncionario(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool VerificarEmpresaVinculada(int empresaId)
        {
            return _funcionarioRepository.GetAll(x => x.EmpresaId == empresaId).Any();
        }
    }
}
