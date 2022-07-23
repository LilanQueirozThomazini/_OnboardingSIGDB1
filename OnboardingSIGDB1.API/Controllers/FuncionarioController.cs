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
using OnboardingSIGDB1.Domain.Filters;
using System.Text.RegularExpressions;
using System.Linq;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioRepository _repository;
        private readonly IGravarFuncionarioService _gravaService;
        private readonly IRemoverFuncionarioService _removeService;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository repository, 
                  IGravarFuncionarioService gravaService, IRemoverFuncionarioService removeService, IMapper mapper)
        {
            _repository = repository;
            _gravaService = gravaService;
            _removeService = removeService;
            _mapper = mapper;
        }



        [HttpGet]
        public IList<FuncionarioConsultaDTO> Get()
        {
            return _repository.GetAllFuncionarios();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var funcionario = _repository.GetFuncionario(id);

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



        [HttpGet("pesquisar")]
        public IEnumerable<FuncionarioConsultaDTO> Get([FromQuery] FiltersFuncionario filters)
        {
            var funcionarios = _repository.GetAllFuncionarios();
            var funcionariosDto = _mapper.Map<IEnumerable<FuncionarioConsultaDTO>>(funcionarios);

            if (filters.Nome != null)
            {
                var regex = new Regex(filters.Nome, RegexOptions.IgnoreCase);
                funcionariosDto = funcionariosDto.Where(f => regex.IsMatch(f.Nome));
            }

            if (filters.CPF != null)
                funcionariosDto = funcionariosDto.Where(f => f.Cpf == filters.CPF);

            if (filters.dtInicial != null && filters.dtFinal != null)
            {
                if (filters.DateTimeValidate())
                {
                    funcionariosDto = funcionariosDto.Where(f => f.DataContratacao >= filters.dtInicial);
                    funcionariosDto = funcionariosDto.Where(f => f.DataContratacao <= filters.dtFinal);
                }

            }
            else if (filters.dtInicial != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao >= filters.dtInicial);
            else if (filters.dtFinal != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao <= filters.dtFinal);
           
            return funcionariosDto;
        }
    }
}
