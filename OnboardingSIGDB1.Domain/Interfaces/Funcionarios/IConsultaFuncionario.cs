using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IConsultaFuncionario
    {
        bool VerificarEmrpesaVinculada(int empresaId);
    }
}
