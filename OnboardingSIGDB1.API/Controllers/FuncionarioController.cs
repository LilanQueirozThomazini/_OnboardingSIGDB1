using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.API.Models;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IRepository<Funcionario> _repository;
        private readonly IGravarFuncionarioService _gravaService;
        private readonly IRemoverFuncionarioService _removeService;

        public FuncionarioController(IRepository<Funcionario> repository, IGravarFuncionarioService gravaService, IRemoverFuncionarioService removeService)
        {
            _repository = repository;
            _gravaService = gravaService;
            _removeService = removeService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService.notificationContext.Notifications);

            return Created($"/api/funcionario/{dto.Id}", dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removeService.Remover(id))
                return BadRequest(_removeService.notificationContext.Notifications);

            return NoContent();
        }
    }
}
