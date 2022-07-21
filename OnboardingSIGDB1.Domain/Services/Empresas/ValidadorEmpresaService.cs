using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class ValidadorEmpresaService: ValidadorBase<Empresa>
    {
        private readonly IRepository<Empresa> _repository;

        public ValidadorEmpresaService(INotificationContext notification, Empresa empresa, IRepository<Empresa> repository)
        {
            notificationContext = notification;
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
            ValidarExiste();
            ValidarCNPJ(entidade.Cnpj);
            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExisteMesmoCNPJ(string cnpj)
        {
            if (_repository.Exist(e => e.Cnpj == cnpj))
                notificationContext.AddNotification(Constantes.sChaveErroMesmoCNPJ, Constantes.sMensagemErroMesmoCNPJ);
        }

        private void ValidarCNPJ(string cnpj)
        {
            if (entidade != null && !ValidadorCPNJ.ValidaCNPJ(cnpj))
                notificationContext.AddNotification(Constantes.sChaveErroCNPJInvalido, Constantes.sMensagemErroCNPJInvalido);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }
    }
}
