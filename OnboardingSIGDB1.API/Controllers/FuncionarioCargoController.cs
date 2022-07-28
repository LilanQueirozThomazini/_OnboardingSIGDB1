using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/funcionarioCargos")]
    [ApiController]
    public class FuncionarioCargoController : ControllerBase
    {
        private readonly IGravarFuncionarioCargoService _gravaService;


        public FuncionarioCargoController(IGravarFuncionarioCargoService gravarFuncionarioCargoService)
        {
            _gravaService = gravarFuncionarioCargoService;
        }

       
        [HttpPost("vincularFuncionarioCargo")]
        public IActionResult Post(FuncionarioCargoDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService._notificationContext.Notifications);

            return Ok(dto);
        }
    }
}
