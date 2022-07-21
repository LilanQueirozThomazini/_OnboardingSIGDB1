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
using AutoMapper;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IRepository<Funcionario> _repository;
        private readonly IGravarFuncionarioService _gravaService;
        private readonly IRemoverFuncionarioService _removeService;
        private readonly IMapper _mapper;

        public FuncionarioController(IRepository<Funcionario> repository, 
                  IGravarFuncionarioService gravaService, IRemoverFuncionarioService removeService, IMapper mapper)
        {
            _repository = repository;
            _gravaService = gravaService;
            _removeService = removeService;
            _mapper = mapper;
        }


      
        [HttpGet]
        public IEnumerable<FuncionarioDTO> Get()
        {
            var funcionarios = _repository.GetAll();
            return _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var funcionario = _repository.Get(x => x.Id == id);

            if (funcionario == null)
                return NotFound("Funcionário não encontrado.");

            return Ok(_mapper.Map<FuncionarioDTO>(funcionario));
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService.notificationContext.Notifications);

            return Created($"/api/funcionario/{dto.Id}", dto);
        }

        [HttpPatch("{id}")]
        public IActionResult VincularFuncionarioEmpresa(int id, [FromBody] FuncionarioEmpresaDTO dto)
        {
            if (!_gravaService.VincularEmpresa(id, dto))
                return BadRequest(_gravaService.notificationContext.Notifications);

            return Created($"/api/funcionario/{id}", dto);
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
