using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text.RegularExpressions;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Empresa : EntityValidator<Empresa>
    {
        public int Id { get; private set; }
        public string Nome
        {
            get { return _nome; }
            private set { _nome = value.Trim(); }

        }
        public string Cnpj
        {
            get { return _cnpj; }
            private set { _cnpj = Regex.Replace(value.Trim(), @"[-,.,/]", string.Empty); }

        }
        public DateTime? DataFundacao { get; private set; }
        public virtual IEnumerable<Funcionario> Funcionarios { get; private set; }

        private string _nome;
        private string _cnpj;

        protected Empresa() { }

        public Empresa(string nome, string cnpj, DateTime? dataFundacao)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = dataFundacao;
        }
        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
        public void AlterarCnpj(string cnpj)
        {
            Cnpj = cnpj;
        }
        public void AlterarDataFundacao(DateTime dataFundacao)
        {
            DataFundacao = dataFundacao;
        }
        public override bool Validar()
        {
            RuleFor(e => e.Nome).NotEmpty().NotNull().MaximumLength(Constantes.QuantidadeMaximaDeCaracteresParaNome);
            RuleFor(e => e.Cnpj).NotEmpty().NotNull().MaximumLength(Constantes.QuantidadeMaximaDeCaracteresParaCNPJ);
            RuleFor(e => e.DataFundacao).GreaterThan(DateTime.MinValue);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
