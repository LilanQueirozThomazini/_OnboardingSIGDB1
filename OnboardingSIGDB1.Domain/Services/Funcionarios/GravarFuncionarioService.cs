using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class GravarFuncionarioService : GravarServiceBase, IGravarFuncionarioService
    {

        private readonly IFuncionarioRepository _repository;
        private Funcionario _funcionario;
        private ValidadorFuncionarioService _validador;

        public GravarFuncionarioService(IFuncionarioRepository repository, 
            INotificationContext notificationContext, IRepository<Empresa> empresaRepository)
        {
            _repository = repository;
            _notificationContext = notificationContext;
            _validador = new ValidadorFuncionarioService(_notificationContext, _funcionario,_repository, empresaRepository);
        }
       
        public bool Alterar(int id, FuncionarioDTO dto)
        {
            _funcionario = _repository.Get(x => x.Id == id);

            _validador.entidade = _funcionario;
            if (_funcionario != null)
            {
                _funcionario.AlteraNome(dto.Nome);
                _funcionario.AlteraCpf(dto.Cpf);
                _funcionario.AlteraDataContratacao(dto.DataContratacao);
            }
            _validador.ValidarAlteracao();

            if (_notificationContext.HasNotifications)
                return false;

            
            _repository.Update(_funcionario);
            return true;
        }

        public bool Inserir(FuncionarioDTO dto)
        {
            _funcionario = new Funcionario(dto.Nome, dto.Cpf, dto.DataContratacao);

            _validador.entidade = _funcionario;
            _validador.ValidarInclusao();

            if (_notificationContext.HasNotifications)
                return false;

            _repository.Add(_funcionario);
            return true;
        }

        public bool VincularEmpresa(FuncionarioEmpresaDTO dto)
        {
            _funcionario = _repository.Get(x => x.Id == dto.FuncionarioId);

            _validador.entidade = _funcionario;
            _validador.ValidarVinculacaoEmpresa(dto.EmpresaId);

            _funcionario.AlteraEmpresa(dto.EmpresaId);

            if (_notificationContext.HasNotifications)
                return false;

            _repository.Update(_funcionario);
            return true;
        }
    }
}
