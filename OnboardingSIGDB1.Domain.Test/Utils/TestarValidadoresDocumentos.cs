using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnboardingSIGDB1.Domain.Test.Utils
{
    public class TestarValidadoresDocumentos
    {
        [Fact]
        public void TestarValidadorCPFValido()
        {
            var cpf = "68656104403";

            Assert.True(ValidadorCPF.ValidaCPF(cpf));
        }


        [Fact]
        public void TestarValidadorCPFInvalido()
        {
            var cpf = "68656104401";

            Assert.False(ValidadorCPF.ValidaCPF(cpf));
        }

        [Fact]
        public void TestarValidadorCNPJValido()
        {
            var cnpj = "92349340000140";

            Assert.True(ValidadorCPNJ.ValidaCNPJ(cnpj));
        }


        [Fact]
        public void TestarValidadorCNPJInvalido()
        {
            var cnpj = "92349340000100";

            Assert.False(ValidadorCPNJ.ValidaCNPJ(cnpj));
        }
    }
}
