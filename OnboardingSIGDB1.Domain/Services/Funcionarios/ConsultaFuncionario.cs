using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ConsultaFuncionario : IConsultaFuncionario
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ConsultaFuncionario(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public bool VerificarEmrpesaVinculada(int empresaId)
        {
            return _funcionarioRepository.GetAll(f => f.EmpresaId == empresaId).Any();
        }
    }
}
