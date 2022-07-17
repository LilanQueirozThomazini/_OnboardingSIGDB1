using System;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class FuncionarioCargo 
    {
        public int CargoId { get; private set; }
        public int FuncionarioId { get; private set; }
        public DateTime? DataVinculo { get; private set; }

        public virtual Cargo Cargo { get; private set; } // virtual nagevação no banco
        public virtual Funcionario Funcionario { get; private set; }

        protected FuncionarioCargo() { }

        public FuncionarioCargo(int cargoId, int funcionarioId, DateTime dataVinculo)
        {
            CargoId = cargoId;
            FuncionarioId = funcionarioId;
            DataVinculo = dataVinculo;
        }
       

    }
}
