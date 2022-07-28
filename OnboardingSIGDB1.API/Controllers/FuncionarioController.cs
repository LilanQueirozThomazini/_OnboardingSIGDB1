using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Filters;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/funcionarios")]
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


        [HttpPatch("vincularEmpresa")]
        public IActionResult VincularFuncionarioEmpresa([FromBody] FuncionarioEmpresaDTO dto)
        {
            if (!_gravaService.VincularEmpresa(dto))
                return BadRequest(_gravaService._notificationContext.Notifications);

            return Created($"/api/funcionario/{dto.FuncionarioId}", dto);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removeService.Remover(id))
                return BadRequest(_removeService.notificationContext.Notifications);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionarioDTO dto)
        {
            if (!_gravaService.Alterar(id, dto))
                return BadRequest(_gravaService._notificationContext.Notifications);

            return Created($"/api/funcionario/{id}", dto);
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

            if (filters.DtInicial != null && filters.DtFinal != null)
            {
                if (filters.DateTimeValidate())
                    funcionariosDto = funcionariosDto.Where(f => f.DataContratacao >= filters.DtInicial && f.DataContratacao <= filters.DtFinal);

            }
            else if (filters.DtInicial != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao >= filters.DtInicial);
            else if (filters.DtFinal != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao <= filters.DtFinal);

            return funcionariosDto;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDTO dto)
        {
            if (!_gravaService.Inserir(dto))
                return BadRequest(_gravaService._notificationContext.Notifications);

            return Ok(dto);
        }
    }
}
