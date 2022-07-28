using Bogus;
using ExpectedObjects;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Test.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnboardingSIGDB1.Domain.Test.Entities
{
    public class FuncionarioTest : IDisposable
    {
        private readonly string _nome;
        private readonly string _cpf;
        private readonly DateTime? _dataContratacao;
        private Faker _faker;

        public FuncionarioTest()
        {
            _faker = new Faker();
            _nome = _faker.Person.FullName;
            _cpf = "68656104403";
         

        }
        public void Dispose()
        {

        }


        [Fact]
        public void DeveCriarFuncionario()
        {
            var funcionarioEsperado = new
            {
                Nome = _nome,
                Cpf = _cpf
            };

            var funcionario = new Funcionario(funcionarioEsperado.Nome, funcionarioEsperado.Cpf, _dataContratacao);

            funcionarioEsperado.ToExpectedObject().ShouldMatch(funcionario);
        }




        [Theory]
        [InlineData("")]
        //[InlineData(null)]
        [InlineData("Nome com mais de 250 caracteres ssssssssaaaassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
        public void NaoDeveOFUncionarioTerUmNomeInvalida(string nomeInvalido)
        {

            Funcionario funcionario = FuncionarioBuilder.Novo().ComNome(nomeInvalido).Build();
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void DeveAlterarNome()
        {
            Funcionario funcionario = FuncionarioBuilder.Novo().ComNome(_nome).Build();

            var _nomeAlterar = _faker.Random.Words(40);

            funcionario.AlteraNome(_nomeAlterar);

            Assert.Equal(_nomeAlterar, funcionario.Nome);
        }



    }
}

