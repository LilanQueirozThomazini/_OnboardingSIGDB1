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

        public GravarFuncionarioService(IRepository<Funcionario> repository, INotificationContext notification)
        {
            _repository = repository;
            notificationContext = notification;
        }

        public bool Alterar(int id, FuncionarioDTO dto)
        {
            return true;
        }

        public bool Inserir(FuncionarioDTO dto)
        {
           // _repository.Add(new Funcionario(dto.Nome, dto.Cpf, dto.DataContratacao));
            return true;
        }

        public bool VincularEmpresa(int id, FuncionarioEmpresaDTO dto)
        {
            return true;
        }
    }
}
