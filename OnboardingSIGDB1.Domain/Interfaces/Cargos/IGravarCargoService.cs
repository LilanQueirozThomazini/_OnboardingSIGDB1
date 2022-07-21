using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces.Cargos
{
    public interface IGravarCargoService : IGravarService
    {
        bool Inserir(CargoDTO dto);
        bool Alterar(int id, CargoDTO dto);
    }
}
