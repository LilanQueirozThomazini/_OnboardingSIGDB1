using OnboardingSIGDB1.Domain.Dto;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface ICargoService
    {
        bool Inserir(CargoDTO dto);
    }
}
