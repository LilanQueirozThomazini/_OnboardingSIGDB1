using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Cargos
{
    public class ValidadorCargoService : ValidadorBase<Cargo>
    {
        private readonly IRepository<Cargo> _repository;

        public ValidadorCargoService(INotificationContext notificationContext, Cargo cargo, IRepository<Cargo> cargoRepository)
        {
            _repository = cargoRepository;
            _notificationContext = notificationContext;
            entidade = cargo;
        }


        private void ValidarExiste()
        {
            if (entidade == null)
                _notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }



        public void ValidarInclusao()
        {
            ValidarEntidade();
            ValidarExisteMesmaDescricao();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarEntidade();
            ValidarExisteMesmaDescricao();
        }

        private void ValidarEntidade()
        {
            if (entidade != null && !entidade.Validar())
                _notificationContext.AddNotifications(entidade.ValidationResult);
        }
        private void ValidarExisteMesmaDescricao()
        {
            if (entidade != null && _repository.Exist(c => c.Descricao == entidade.Descricao && c.Id != entidade.Id))
                _notificationContext.AddNotification(Constantes.sChaveErroCargoMesmaDescricao, Constantes.sMensagemErroCargoMesmaDescricao);
        }
    }
}
