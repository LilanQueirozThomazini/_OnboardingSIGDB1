using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IGravarCargoService _gravarService;
        private readonly IRemoverCargoService _removerService;

        public CargoController(IGravarCargoService gravarcargoService, IRemoverCargoService removerService)
        {
            _gravarService = gravarcargoService;
            _removerService = removerService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDTO dto)
        {
            if (!_gravarService.Inserir(dto))
                return BadRequest(_gravarService.notificationContext.Notifications);

            return Created($"/api/cargo/{dto.Id}", dto);

            //TODO: como mostrar o ID CRIADO?
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CargoDTO dto)
        {
            if (!_gravarService.Alterar(id, dto))
                return BadRequest(_gravarService.notificationContext.Notifications);

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
