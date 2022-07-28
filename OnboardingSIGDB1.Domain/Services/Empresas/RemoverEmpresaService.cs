using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class RemoverEmpresaService : IRemoverEmpresaService
    {
        public INotificationContext notificationContext { get; set; }

        private readonly IRepository<Empresa> _repository;
        private readonly IConsultaFuncionario _consultaFuncionario;

        public RemoverEmpresaService(INotificationContext notificationContext, IRepository<Empresa> repository, IConsultaFuncionario consultaFuncionario)
        {
            this.notificationContext = notificationContext;
            _repository = repository;
            _consultaFuncionario = consultaFuncionario;
        }

        public bool Remover(int id)
        {
            var empresa = _repository.Get(e => e.Id == id);

            if (empresa == null)
            {
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);
                return false;
            }
            if (_consultaFuncionario.VerificarExisteEmpresaVinculada(empresa.Id))
                notificationContext.AddNotification(Constantes.sChaveErroFuncionarioEmpresa, Constantes.sMensagemErroFuncionarioEmpresa);

            if (notificationContext.HasNotifications)
                return false;

            _repository.Delete(empresa);
            return true;
        }
        
    }
}
