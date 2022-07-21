using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class GravarCargoService : GravarServiceBase, IGravarCargoService
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public GravarCargoService(IRepository<Cargo> cargoRepository, INotificationContext notification)
        {
            _cargoRepository = cargoRepository;
            notificationContext = notification;
        }

        public bool Inserir(CargoDTO dto)
        {
            _cargoRepository.Add(new Cargo(dto.Descricao));
            return true;
        }

        public bool Alterar(int id, CargoDTO dto)
        {
            //_cargo = _cargoRepository.Get(c => c.Id == id);
            //_cargo.AlterarDescricao(dto.Descricao);

            //_validador.entidade = _cargo;
            //_validador.ValidarAlteracao();

            //if (notificationContext.HasNotifications)
            //    return false;

            //_cargoRepository.Update(_cargo);
            return true;
        }
    }
}
