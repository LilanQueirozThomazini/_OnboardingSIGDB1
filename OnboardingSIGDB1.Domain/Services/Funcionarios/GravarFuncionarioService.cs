using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : GravarServiceBase, IGravarFuncionarioService
    {

        private readonly IRepository<Funcionario> _repository;
        private Funcionario _funcionario;
        private ValidadorFuncionarioService _validador;

        public GravarFuncionarioService(IRepository<Funcionario> repository, 
            INotificationContext notification, IRepository<Empresa> empresaRepository)
        {
            _repository = repository;
            notificationContext = notification;
            _validador = new ValidadorFuncionarioService(notification, _funcionario,_repository, empresaRepository);
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            _funcionario = _repository.Get(x => x.Id == id);
            _funcionario.AlteraNome(dto.Nome);
            _funcionario.AlteraCpf(dto.Cpf);
            _funcionario.AlteraDataContratacao(dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarAlteracao();

            if (notificationContext.HasNotifications)
                return false;

            _repository.Update(_funcionario);
            return true;
        }

        public bool Inserir(FuncionarioDTO dto)
        {
            _funcionario = new Funcionario(dto.Nome, dto.Cpf, dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarInclusao();

            if (notificationContext.HasNotifications)
                return false;

            _repository.Add(_funcionario);
            return true;
        }

        public bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto)
        {
            _funcionario = _repository.Get(x => x.Id == id);

            _validador.entidade = _funcionario;
            _validador.ValidarVinculacaoEmpresa(dto.EmpresaId);

            _funcionario.AlteraEmpresa(dto.EmpresaId);

            if (notificationContext.HasNotifications)
                return false;

            _repository.Update(_funcionario);
            return true;
        }
    }
}
