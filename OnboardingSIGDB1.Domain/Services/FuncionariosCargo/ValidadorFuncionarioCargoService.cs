using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class ValidadorFuncionarioCargoService: ValidadorBase<FuncionarioCargo>
    {
        private IRepository<FuncionarioCargo> _repository;
        private IRepository<Funcionario> _repositoryFuncionario;

        public ValidadorFuncionarioCargoService(IRepository<FuncionarioCargo> repository, 
            IRepository<Funcionario> repositoryFuncionario,
            INotificationContext notification,
            FuncionarioCargo funcionarioCargo)
        {
            _repository = repository;
            _repositoryFuncionario = repositoryFuncionario;
            notificationContext = notification;
            entidade = funcionarioCargo;
            
        }

        public void ValidarVinculoFuncionarioCargo()
        {
            ValidarEmpresaVinculada();
            ValidarExiste();
            ValidarEntidade();
        }

        private void ValidarEmpresaVinculada()
        {
            var funcionario = _repositoryFuncionario.Get(x => x.Id == entidade.FuncionarioId);

            if (funcionario.EmpresaId == null)
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioSemEmpresa, Constantes.sMensagemErroFuncionarioSemEmpresa);
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (_repository.Exist(x => x.CargoId == entidade.CargoId && x.FuncionarioId == entidade.FuncionarioId))
                notificationContext.AddNotification(Constantes.sChaveErrooFuncionarioCargo, Constantes.sMensagemErrooFuncionarioCargo);
        }
    }
}
