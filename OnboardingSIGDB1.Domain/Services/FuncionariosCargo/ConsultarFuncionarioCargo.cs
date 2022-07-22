using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class ConsultarFuncionarioCargo : IConsultarFuncionarioCargo
    {
        private readonly IRepository<FuncionarioCargo> _funcionarioCargoRepository;

        public ConsultarFuncionarioCargo(IRepository<FuncionarioCargo> funcionarioCargoRepository)
        {
            _funcionarioCargoRepository = funcionarioCargoRepository;
        }

        public bool VerificarExisteVinculo(int cargoId)
        {
            return _funcionarioCargoRepository.GetAll(fc => fc.CargoId == cargoId).Any();
        }
    }
}
