using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces.Empresas
{
    public interface IGravarEmpresaService : IGravarService
    {
        bool Inserir(EmpresaDTO dto);
        bool Alterar(int id, EmpresaDTO dto);
    }
}
