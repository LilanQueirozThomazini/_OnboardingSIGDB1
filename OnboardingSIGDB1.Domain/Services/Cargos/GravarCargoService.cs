using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class GravarCargoService : GravarServiceBase, IGravarCargoService
    {
        private readonly IRepository<Cargo> _repository;
        private ValidadorCargoService _validador;
        private Cargo _cargo;

        public GravarCargoService(IRepository<Cargo> cargoRepository, INotificationContext notification)
        {
            _repository = cargoRepository;
            notificationContext = notification;
            _validador = new ValidadorCargoService(notification, _cargo, _repository);
        }

        public bool Inserir(CargoDTO dto)
        {
            _cargo = new Cargo(dto.Descricao);

            _validador.entidade = _cargo;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _repository.Add(_cargo);
            return true;
        }

        public bool Alterar(int id, CargoDTO dto)
        {
            _cargo = _repository.Get(c => c.Id == id);
            _cargo.AlteraDescricao(dto.Descricao);

            _validador.entidade = _cargo;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _repository.Update(_cargo);
            return true;
        }
    }
}
