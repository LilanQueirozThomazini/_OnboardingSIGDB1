using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        
        public INotificationContext notificationContext { get; set; }

        public RemoverFuncionarioService(IFuncionarioRepository repository, INotificationContext notificationContext)
        {
            _repository = repository;
            this.notificationContext = notificationContext;
        }
        public bool Remover(int id)
        {
            var funcionario = _repository.Get(x => x.Id == id);

            if (funcionario == null)
                notificationContext.AddNotification(Constantes.sChaveErroLocalizar, Constantes.sMensagemErroLocalizar);

            if (notificationContext.HasNotifications)
                return false;

            _repository.Delete(funcionario);
            return true;
        }
    }
}
