using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using System.Collections.Generic;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/cargos")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IGravarCargoService _gravarService;
        private readonly IRemoverCargoService _removerService; 
        private readonly IMapper _mapper;
        private readonly IRepository<Cargo> _repository;

        public CargoController(IGravarCargoService gravarcargoService, IRemoverCargoService removerService, IRepository<Cargo> cargoRepository, IMapper mapper)
        {
            _gravarService = gravarcargoService;
            _removerService = removerService;
            _repository = cargoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CargoDTO> Get()
        {
            var cargos = _repository.GetAll();
            var cargosDto = _mapper.Map<IEnumerable<CargoDTO>>(cargos);
            return cargosDto;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cargo = _repository.Get(c => c.Id == id);
            if (cargo == null)
                return BadRequest("Cargo não encontrado.");

            var cargoDto = _mapper.Map<CargoDTO>(cargo);

            return Ok(cargoDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDTO dto)
        {
            if (!_gravarService.Inserir(dto))
                return BadRequest(_gravarService._notificationContext.Notifications);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CargoDTO dto)
        {
            if (!_gravarService.Alterar(id, dto))
                return BadRequest(_gravarService._notificationContext.Notifications);

            return Created($"/api/cargo/{id}", dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removerService.Remover(id))
                return BadRequest(_removerService.notificationContext.Notifications);

            return NoContent();
        }
    }
}
