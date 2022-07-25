using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class ValidadorFuncionarioService : ValidadorBase<Funcionario>
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IRepository<Empresa> _empresaRepository;

        public ValidadorFuncionarioService(INotificationContext notificationContext,
                        Funcionario funcionario, IFuncionarioRepository funcionarioRepository,
                        IRepository<Empresa> empresaRepository)
        {
            _notificationContext = notificationContext;
            entidade = funcionario;
            _repository = funcionarioRepository;
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
            if (ValidarExiste())
            {
                ValidarCPF(entidade.Cpf);
                ValidarEntidade();
            }
        }

        public void ValidarVinculacaoEmpresa(int empresaId)
        {
            if (ValidarExiste())
            {
                ValidarEmpresaVinculada();
                ValidarEmpresaExiste(empresaId);
            }
        }

        private void ValidarCPF(string cpf)
        {
            if (!ValidadorCPF.ValidaCPF(cpf))
                _notificationContext.AddNotification(Constantes.sChaveErroCPFInvalido, Constantes.sMensagemErroCPFInvalido);
        }

        private void ValidarEntidade()
        {
            if (entidade != null && !entidade.Validar())
                _notificationContext.AddNotifications(entidade.ValidationResult);
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

        private void ValidarExisteMesmoCPF(string cpf)
        {
            if (entidade != null && _repository.Exist(x => x.Cpf == cpf))
                _notificationContext.AddNotification(Constantes.sChaveErroMesmoCPF, Constantes.sMensagemErroMesmoCPF);
        }

        private void ValidarEmpresaVinculada()
        {
            if (entidade != null && entidade.EmpresaId.HasValue)
                _notificationContext.AddNotification(Constantes.sChaveErroEmpresaVinculada, Constantes.sMensagemErroEmpresaVinculada);
        }

        private void ValidarEmpresaExiste(int empresaId)
        {
            if (entidade != null && !_empresaRepository.Exist(x => x.Id == empresaId))
                _notificationContext.AddNotification(Constantes.sChaveErroEmpresaNaoLocalizadaParaVincular, Constantes.sMensagemErroEmpresaNaoLocalizadaParaVincular);
        }
    }
}
