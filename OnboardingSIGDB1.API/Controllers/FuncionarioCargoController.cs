using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionarioCargoController : ControllerBase
    {
        private readonly IGravarFuncionarioCargoService _gravaService;


        public FuncionarioCargoController(IGravarFuncionarioCargoService gravarFuncionarioCargoService)
        {
            _gravaService = gravarFuncionarioCargoService;
        }

       
        [HttpPost]
        public IActionResult Post(FuncionarioCargoDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService.notificationContext.Notifications);

            return Created(string.Empty, dto);
        }
    }
}
