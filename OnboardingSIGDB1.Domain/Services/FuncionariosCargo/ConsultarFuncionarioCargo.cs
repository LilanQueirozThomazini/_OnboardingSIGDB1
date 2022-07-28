using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using System.Linq;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class ConsultarFuncionarioCargo : IConsultarFuncionarioCargo
    {
        private readonly IRepository<FuncionarioCargo> _repository;

        public ConsultarFuncionarioCargo(IRepository<FuncionarioCargo> repositoryFuncionarioCargo)
        {
            _repository = repositoryFuncionarioCargo;
        }

        public bool VerificarExisteVinculo(int cargoId)
        {
            return _repository.GetAll(x => x.CargoId == cargoId).Any();
        }
    }
}
