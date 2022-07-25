using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using System;

namespace OnboardingSIGDB1.Domain.Services.Empresas
{
    public class GravarEmpresaService : GravarServiceBase, IGravarEmpresaService
    {
        private readonly IRepository<Empresa> _repository;
        private Empresa _empresa;
        private ValidadorEmpresaService _validador;

        public GravarEmpresaService(IRepository<Empresa> empresaRepository, INotificationContext notificationContext)
        {
            _repository = empresaRepository;
            _notificationContext = notificationContext;
            _validador = new ValidadorEmpresaService(_notificationContext, _empresa, _repository);
        }

        public bool Alterar(int id, EmpresaDTO dto)
        {
            _empresa = _repository.Get(x => x.Id == id);
            _validador.entidade = _empresa;
            if (_empresa != null)
            {
                _empresa.AlterarNome(dto.Nome);
                _empresa.AlterarCnpj(dto.Cnpj);
                _empresa.AlterarDataFundacao(dto.DataFundacao);
            }
                _validador.ValidarAlteracao();

            if (_notificationContext.HasNotifications)
                return false;

           
            _repository.Update(_empresa);
            return true;
        }

        public bool Inserir(EmpresaDTO dto)
        {
            _empresa = new Empresa(dto.Nome, dto.Cnpj, dto.DataFundacao);

            _validador.entidade = _empresa;
            _validador.ValidarInclusao();

            if (_notificationContext.HasNotifications)
                return false;

            _repository.Add(_empresa);
            return true;
        }
    }
}
