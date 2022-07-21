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
        private readonly IRepository<Empresa> _empresaRepository;

        public GravarEmpresaService(IRepository<Empresa> empresaRepository, INotificationContext notification)
        {
            _empresaRepository = empresaRepository;
            notificationContext = notification;
        }

        public bool Alterar(int id, EmpresaDTO dto)
        {
            return true;
        }

        public bool Inserir(EmpresaDTO dto)
        {
            _empresaRepository.Add(new Empresa(dto.Nome, dto.Cnpj, dto.DataFundacao));
            return true;
        }
    }
}
