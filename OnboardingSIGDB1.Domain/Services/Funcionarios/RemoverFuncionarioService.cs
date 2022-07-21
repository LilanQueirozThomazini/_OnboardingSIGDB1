﻿using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services.Funcionarios
{
    public class RemoverFuncionarioService : IRemoverFuncionarioService
    {
        private readonly IRepository<Funcionario> _repository;

        public INotificationContext notificationContext { get; set; }

        public RemoverFuncionarioService(IRepository<Funcionario> repository, INotificationContext notificationContext)
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