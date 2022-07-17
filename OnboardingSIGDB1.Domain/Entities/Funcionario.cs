using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome
        {
            get { return _nome; }
            private set { _nome = value.Trim(); }

        }
        public string Cpf
        {
            get { return _cpf; }
            private set { _cpf = Regex.Replace(value.Trim(), @"[-,.,/]", string.Empty); }

        }
        public DateTime DataContratacao { get; private set; }
        public int EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public virtual IEnumerable<FuncionarioCargo> FuncionarioCargo { get; private set; }


        private string _nome;
        private string _cpf;

        protected Funcionario() { }

        public Funcionario(string nome, string cpf, DateTime dataContratacao, Empresa empresa)
        {
            Nome = nome;
            Cpf = cpf;
            DataContratacao = dataContratacao;
            Empresa = empresa;

        }

        public void AlteraNome(string nome)
        {
            Nome = nome;
        }
        public void AlteraCpf(string cpf)
        {
            Cpf = cpf;
        }
        public void AlteraDataContratacao(DateTime dataContratacao)
        {
            DataContratacao = dataContratacao;
        }


        
    }
}
