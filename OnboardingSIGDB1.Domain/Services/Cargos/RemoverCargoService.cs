using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class RemoverCargoService : IRemoverCargoService
    {
        public INotificationContext notificationContext { get; set; }
        private readonly IRepository<Cargo> _repository;
        private readonly IConsultarFuncionarioCargo _consultarFuncionarioCargo;

        public RemoverCargoService(IRepository<Cargo> repositoryCargo, INotificationContext notification, IConsultarFuncionarioCargo consultarFuncionarioCargo)
        {
            notificationContext = notification;
            _repository = repositoryCargo;
            _consultarFuncionarioCargo = consultarFuncionarioCargo;
            
        }

        public bool Remover(int id)
        {
            var cargo = _repository.Get(x => x.Id == id);

            if (cargo == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (_consultarFuncionarioCargo.VerificarExisteVinculo(cargo.Id))
                notificationContext.AddNotification(Constantes.sChaveErroCargoFuncionario, Constantes.sMensagemErroCargoFuncionario);

            if (notificationContext.HasNotifications)
                return false;

            _repository.Delete(cargo);
            return true;
        }
    }
}
