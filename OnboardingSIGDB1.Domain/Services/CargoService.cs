using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services
{
    
    public class CargoService : ICargoService
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoService(IRepository<Cargo> cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public bool Inserir(CargoDTO dto)
        {
            _cargoRepository.Add(new Cargo(dto.Descricao));
            _cargoRepository.Commit();
            return true;
        }
    }
}
