using Bogus;
using ExpectedObjects;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Test.Builders;
using System;
using Xunit;
using Xunit.Abstractions;

namespace OnboardingSIGDB1.Domain.Test.Entities
{
    public class CargoTest  : IDisposable
    {
        private readonly string _descricao;
        private Faker _faker;

        public CargoTest()
        {
            _faker = new Faker();
            _descricao = _faker.Random.Words(40);
            
        }
        public void Dispose()
        {
           
        }


        [Fact]
        public void DeveCriarCargo()
        {
            var cargoEsperado = new
            {
                Descricao = _descricao
            };

            var cargo = new Cargo(cargoEsperado.Descricao);

            cargoEsperado.ToExpectedObject().ShouldMatch(cargo);
        }

       


        [Theory]
        [InlineData("")]
        //[InlineData(null)]
        [InlineData("Descrição com mais de 250 caracteres sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
        public void NaoDeveOCargoTerUmaDescricaoInvalida(string descricaoInvalida)
        {
            
            Cargo cargo = CargoBuilder.Novo().ComDescricao(descricaoInvalida).Build();
            Assert.False(cargo.Validar());
        }
        [Fact]
        public void DeveAlterarDescricao()
        {
            Cargo cargo = CargoBuilder.Novo().ComDescricao(_descricao).Build();

            var _descricaoAlterar = _faker.Random.Words(40);

            cargo.AlteraDescricao(_descricaoAlterar);

            Assert.Equal(_descricaoAlterar, cargo.Descricao);
        }

        [Theory]
        [InlineData("")]
        //[InlineData(null)]
        [InlineData("Alterando a descrição com mais de 250 caracteres ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
        public void NaoDeveOCargoTerUmaDescricaoInvalidaNaAlteracao(string descricaoInvalida)
        {
            Cargo cargo = CargoBuilder.Novo().ComDescricao(_descricao).Build();
            cargo.AlteraDescricao(descricaoInvalida);
            Assert.False(cargo.Validar());
        }


    }
}
