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

        public FuncionarioController(IRepository<Funcionario> repository, IGravarFuncionarioService gravaService)
        {
            _repository = repository;
            _gravaService = gravaService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService.notificationContext.Notifications);

            return Created($"/api/funcionario/{dto.Id}", dto);
        }
    }
}
