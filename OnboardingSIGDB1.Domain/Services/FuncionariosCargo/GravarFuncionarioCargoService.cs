﻿using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services.FuncionariosCargo
{
    public class GravarFuncionarioCargoService : GravarServiceBase, IGravarFuncionarioCargoService
    {
        private readonly IRepository<FuncionarioCargo> _funcionarioCargoRepository;
        private readonly IRepository<Cargo> _repositoryCargo;
        private FuncionarioCargo _funcionarioCargo;
        private ValidadorFuncionarioCargoService _validador;


        public GravarFuncionarioCargoService(IRepository<FuncionarioCargo> funcionarioCargoRepository, 
            INotificationContext notification,
            IFuncionarioRepository funcionarioRepository, IRepository<Cargo> repositoryCargo)
        {
            _funcionarioCargoRepository = funcionarioCargoRepository;
            notificationContext = notification;
            _repositoryCargo = repositoryCargo;
            _validador = new ValidadorFuncionarioCargoService(funcionarioCargoRepository, 
                funcionarioRepository, notification, _funcionarioCargo, _repositoryCargo) ;
        }
 



        public bool Inserir(FuncionarioCargoDTO dto)
        {
            _funcionarioCargo = new FuncionarioCargo(dto.CargoId, dto.FuncionarioId, dto.DataVinculo);

            _validador.entidade = _funcionarioCargo;
            _validador.ValidarVinculoFuncionarioCargo();

            if (notificationContext.HasNotifications)
                return false;

            _funcionarioCargoRepository.Add(_funcionarioCargo);
            return true;
        }
    }
}
