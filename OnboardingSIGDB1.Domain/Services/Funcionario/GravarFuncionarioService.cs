using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionario;
using System;

namespace OnboardingSIGDB1.Domain.Services.Funcionario
{
    public class GravarFuncionarioService : GravarServiceBase, IGravarFuncionarioService
    {

        private readonly IFuncionarioRepository _repository;

        public GravarFuncionarioService(IFuncionarioRepository repository, INotificationContext notification)
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
