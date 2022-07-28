using Bogus;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Test.Builders
{
    public class FuncionarioBuilder
    {
        private string _nome;
        private string _cpf;
        private DateTime? _dataContratacao;

        public static FuncionarioBuilder Novo()
        {
            var fake = new Faker();
            var funcionarioBuilder = new FuncionarioBuilder();
            funcionarioBuilder.ComNome(fake.Person.FullName);
            funcionarioBuilder.ComCpf("686.561.044-03");
            return funcionarioBuilder;
        }

        public Funcionario Build()
        {
            return new Funcionario(_nome, _cpf, _dataContratacao);
        }

        public FuncionarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public FuncionarioBuilder ComCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }
        
    }
}
