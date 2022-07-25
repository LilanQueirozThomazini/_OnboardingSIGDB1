namespace OnboardingSIGDB1.Domain.Utils
{
    public static class Constantes
    {
        public const int QuantidadeMaximaDeCaracteresParaDescricao = 250;
        public const int QuantidadeMaximaDeCaracteresParaNome = 150;
        public const int QuantidadeMaximaDeCaracteresParaCPF = 11;
        public const int QuantidadeMaximaDeCaracteresParaCNPJ = 14;

        public const string sChaveFiltroDataFinalMaiorQueInicial = "ErroFilterDatas";
        public const string sMensagemFiltroDataFinalMaiorQueInicial = "A Data Final não pode ser maior que a Data Inicial.";
        public const string sChaveErroInclusao = "ErroInserir";
        public const string sMensagemErroInclusao = "Não foi possível realizar a inclusão.";
        public const string sChaveErroAlteracao = "ErroAlterar";
        public const string sMensagemErroAlteracao = "Não foi possível realizar a alteração.";
        public const string sChaveErroLocalizar = "ErroNaoLocalizado";
        public const string sMensagemErroLocalizar = "O registro não foi localizado.";
        public const string sChaveErroRemover = "ErroRemover";
        public const string sMensagemErroRemover = "Não foi possível realizar a remoção.";
        public const string sChaveErroMesmoCPF = "ErroExisteCPF";
        public const string sMensagemErroMesmoCPF = "CPF já existe na base.";
        public const string sChaveErroMesmoCNPJ = "ErroExisteCNPJ";
        public const string sMensagemErroMesmoCNPJ = "CNPJ já existe na base.";
        public const string sChaveErroCPFInvalido = "ErroCPFInvalido";
        public const string sMensagemErroCPFInvalido = "CPF inválido.";
        public const string sChaveErroCNPJInvalido = "ErroCNPJInvalido";
        public const string sMensagemErroCNPJInvalido = "CNPJ inválido.";
        public const string sChaveErroEmpresaVinculada = "ErroEmpresaVinculada";
        public const string sMensagemErroEmpresaVinculada = "Funcionário já possui empresa vinculada.";
        public const string sChaveErroEmpresaNaoLocalizadaParaVincular = "ErroEmpresaNaoLocalizadaVinculo";
        public const string sMensagemErroEmpresaNaoLocalizadaParaVincular = "Empresa não localizada para vincular.";
        public const string sChaveErroFuncionarioSemEmpresa = "ErroFuncionarioSemEmpresa";
        public const string sMensagemErroFuncionarioSemEmpresa = "Funcionáio não está vinculado com uma empresa.";
        public const string sChaveErroFuncionarioCargo = "ErroFuncionarioCargo";
        public const string sMensagemErroFuncionarioCargo = "Funcionário já vinculado ao cargo.";
        public const string sChaveErroFuncionarioNaoLocalizado = "ErroFuncionarioNaoLocalizado";
        public const string sMensagemFuncionarioNaoLocalizado = "Funcionário não localizado para vincular.";
        public const string sChaveErroCargoNaoLocalizado = "ErroFuncionarioCargo";
        public const string sMensagemCargoNaoLocalizado = "Cargo não localizado para vincular.";


        public const string sChaveErroCargoFuncionario = "ErroCargoVinculoFuncionario";
        public const string sMensagemErroCargoFuncionario = "Cargo possui fuincionários vinculados.";
        public const string sChaveErroFuncionarioEmpresa = "ErroFuncionarioEmpresa";
        public const string sMensagemErroFuncionarioEmpresa = "Empresa possui funcionários vinculados";
        public const string sChaveErroCargoMesmaDescricao = "ErroCargoMesmaDescricao";
        public const string sMensagemErroCargoMesmaDescricao = "Existe um cargo com a mesma descrição informada.";
    }
}
