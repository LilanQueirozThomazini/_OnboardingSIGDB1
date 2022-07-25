using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class ValidadorEmpresaService: ValidadorBase<Empresa>
    {
        private readonly IRepository<Empresa> _repository;

        public ValidadorEmpresaService(INotificationContext notificationContext, Empresa empresa, IRepository<Empresa> repository)
        {
            _notificationContext = notificationContext;
            entidade = empresa;
            _repository = repository;
        }

        public void ValidarInclusao()
        {
            ValidarExisteMesmoCNPJ(entidade.Cnpj);
            ValidarCNPJ(entidade.Cnpj);
            ValidarEntidade();
        }

        public void ValidarAlteracao()
        {
            if (ValidarExiste())
            {
                ValidarCNPJ(entidade.Cnpj);
                ValidarEntidade();
            }
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                _notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExisteMesmoCNPJ(string cnpj)
        {
            if (_repository.Exist(e => e.Cnpj == cnpj))
                _notificationContext.AddNotification(Constantes.sChaveErroMesmoCNPJ, Constantes.sMensagemErroMesmoCNPJ);
        }

        private void ValidarCNPJ(string cnpj)
        {
            if (!ValidadorCPNJ.ValidaCNPJ(cnpj))
                _notificationContext.AddNotification(Constantes.sChaveErroCNPJInvalido, Constantes.sMensagemErroCNPJInvalido);
        }

        private bool ValidarExiste()
        {
            if (entidade == null)
            {
                _notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
                return false;
            
            }
            return true;
        }
    }
}
