using Bogus;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Test.Builders
{
    public class CargoBuilder
    {
        private string _descricao;

        public static CargoBuilder Novo()
        {
            var fake = new Faker();
            var cargoBuilder = new CargoBuilder();
            cargoBuilder.ComDescricao(fake.Random.Words(2));
            return cargoBuilder;
        }

        public Cargo Build()
        {
            return new Cargo(_descricao);
        }

        public CargoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
    }
}
