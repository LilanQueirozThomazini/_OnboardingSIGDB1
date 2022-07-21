using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IGravarEmpresaService _gravarService;

        public EmpresaController(IGravarEmpresaService gravarEmpresaService)
        {
            _gravarService = gravarEmpresaService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmpresaDTO dto)
        {
            if (!_gravarService.Inserir(dto))
                return BadRequest(_gravarService.notificationContext.Notifications);

            return Created($"/api/empresa/{dto.Id}", dto);
        }
    }
}
