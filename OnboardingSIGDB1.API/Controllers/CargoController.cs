using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IGravarCargoService _gravarcargoService;

        public CargoController(IGravarCargoService gravarcargoService)
        {
            _gravarcargoService = gravarcargoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDTO dto)
        {
            if (!_gravarcargoService.Inserir(dto))
                return BadRequest(_gravarcargoService.notificationContext.Notifications);

            return Created($"/api/cargo/{dto.Id}", dto);
        }
    }
}
