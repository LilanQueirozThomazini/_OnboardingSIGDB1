using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces.Funcionarios
{
    public interface IGravarFuncionarioService : IGravarService
    {
        bool Inserir(FuncionarioDTO dto);
        bool Alterar(int id, FuncionarioDTO dto);
        bool VincularEmpresa(FuncionarioEmpresaDTO dto);
    }
}
