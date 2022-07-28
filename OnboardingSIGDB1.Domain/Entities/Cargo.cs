using FluentValidation;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Utils;
using System.Collections.Generic;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Cargo : EntityValidator<Cargo>
    {
        public int Id { get; private set; }


        public string? Descricao
        {
            get { return _descricao; }
            private set { _descricao = value.Trim(); }

        }
        public virtual IEnumerable<FuncionarioCargo> FuncionarioCargo { get; private set; }
        private string _descricao;

        protected Cargo() { }

        public Cargo(string? descricao)
        {
            Descricao = descricao;
        }

        public void AlteraDescricao(string? descricao)
        {
            Descricao = descricao;

        }

        public override bool Validar()
        {
            RuleFor(x => x.Descricao).NotEmpty().NotNull().MaximumLength(Constantes.QuantidadeMaximaDeCaracteresParaDescricao);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
