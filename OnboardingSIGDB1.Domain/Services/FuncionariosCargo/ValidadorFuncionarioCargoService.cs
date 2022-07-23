using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class ValidadorFuncionarioCargoService : ValidadorBase<FuncionarioCargo>
    {
        private IRepository<FuncionarioCargo> _repository;
        private IRepository<Cargo> _repositoryCargo;
        private IFuncionarioRepository _repositoryFuncionario;

      

        public ValidadorFuncionarioCargoService(IRepository<FuncionarioCargo> repository,
            IFuncionarioRepository repositoryFuncionario,
            INotificationContext notification,
            FuncionarioCargo funcionarioCargo,
            IRepository<Cargo> repositoryCargo)
        {
            _repository = repository;
            _repositoryFuncionario = repositoryFuncionario;
            notificationContext = notification;
            entidade = funcionarioCargo;
            _repositoryCargo = repositoryCargo;

        }

        public void ValidarVinculoFuncionarioCargo()
        {
            bool validaCargo = ValidarExisteCargo();
            bool validaFuncionario = ValidarExisteFuncionario();
            if (ValidarEntidade() && validaCargo  && validaFuncionario)
            {
                ValidarEmpresaVinculada();
                ValidarExisteVinculo();
            }
        }

        private void ValidarEmpresaVinculada()
        {
            var funcionario = _repositoryFuncionario.Get(x => x.Id == entidade.FuncionarioId);

            if (funcionario.EmpresaId == null)
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioSemEmpresa, Constantes.sMensagemErroFuncionarioSemEmpresa);

        }

        private bool ValidarEntidade()
        {
            bool validaEntidade = entidade.Validar();
            if (!validaEntidade)
                notificationContext.AddNotifications(entidade.ValidationResult);
            return validaEntidade;
        }

        private bool ValidarExisteCargo()
        {
            if (!_repositoryCargo.Exist(x => x.Id == entidade.CargoId))
            {
                notificationContext.AddNotification(Constantes.sChaveErroCargoNaoLocalizado, Constantes.sMensagemCargoNaoLocalizado);
                return false;
            }

            return true;
        }

        private bool ValidarExisteFuncionario()
        {
            if (!_repositoryFuncionario.Exist(x => x.Id == entidade.FuncionarioId))
            {
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioNaoLocalizado, Constantes.sMensagemFuncionarioNaoLocalizado);
                return false;
            }
            return true;
        }

        private void ValidarExisteVinculo()
        {
            if (_repository.Exist(x => x.CargoId == entidade.CargoId && x.FuncionarioId == entidade.FuncionarioId))
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioCargo, Constantes.sMensagemErroFuncionarioCargo);

        }
    }
}
