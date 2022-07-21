using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ValidadorFuncionarioService : ValidadorBase<Funcionario>
    {
        private readonly IRepository<Funcionario> _repository;
        private readonly IRepository<Empresa> _empresaRepository;

        public ValidadorFuncionarioService(INotificationContext notification,
                        Funcionario funcionario, IRepository<Funcionario> repository, 
                        IRepository<Empresa> empresaRepository)
        {
            notificationContext = notification;
            entidade = funcionario;
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        public void ValidarInclusao()
        {
            ValidarExisteMesmoCPF(entidade.Cpf);
            ValidarCPF(entidade.Cpf);
            ValidarEntidade();
        }

        public void ValidarAlteracao()
        {
            ValidarExiste();
            ValidarCPF(entidade.Cpf);
            ValidarEntidade();
        }

        public void ValidarVinculacaoEmpresa(int empresaId)
        {
            ValidarExiste();
            ValidarEmpresaVinculada();
            ValidarEmpresaExiste(empresaId);
        }

        private void ValidarCPF(string cpf)
        {
            if (!ValidadorCPF.ValidaCPF(cpf))
                notificationContext.AddNotification(Constantes.sChaveErroCPFInvalido, Constantes.sMensagemErroCPFInvalido);
        }

        private void ValidarEntidade()
        {
            if (!entidade.Validar())
                notificationContext.AddNotifications(entidade.ValidationResult);
        }

        private void ValidarExiste()
        {
            if (entidade == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
        }

        private void ValidarExisteMesmoCPF(string cpf)
        {
            if (_repository.Exist(x => x.Cpf == cpf))
                notificationContext.AddNotification(Constantes.sChaveErroMesmoCPF, Constantes.sMensagemErroMesmoCPF);
        }

        private void ValidarEmpresaVinculada()
        {
            if (entidade != null && entidade.EmpresaId.HasValue)
                notificationContext.AddNotification(Constantes.sChaveErroEmpresaVinculada, Constantes.sMensagemErroEmpresaVinculada);
        }

        private void ValidarEmpresaExiste(int empresaId)
        {
            if (!_empresaRepository.Exist(e => e.Id == empresaId))
                notificationContext.AddNotification(Constantes.sChaveErroEmpresaNaoLocalizadaParaVincular, Constantes.sMensagemErroEmpresaNaoLocalizadaParaVincular);
        }
    }
}
