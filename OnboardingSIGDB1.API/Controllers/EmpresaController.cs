using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Filters;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/v1/empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IGravarEmpresaService _gravarService;
        private readonly IRemoverEmpresaService _removerService;
        private readonly IRepository<Empresa> _repository;
        private readonly IMapper _mapper;

        public EmpresaController(IGravarEmpresaService gravarService, IRemoverEmpresaService removerService, IRepository<Empresa> empresaRepository, IMapper mapper)
        {
            _gravarService = gravarService;
            _removerService = removerService;
            _repository = empresaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EmpresaDTO> Get()
        {
            var empresas = _repository.GetAll();
            var empresasDto = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            return empresasDto;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var empresa = _repository.Get(x => x.Id == id);

            if (empresa == null)
                return NotFound("Empresa não encontrada.");

            var empresaDto = _mapper.Map<EmpresaDTO>(empresa);
            return Ok(empresaDto);
        }

        [HttpGet("pesquisar")]
        public IEnumerable<EmpresaDTO> Get([FromQuery] FiltersEmpresa filters)
        {
            var empresas = _repository.GetAll();
            var empresasDto = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            if (filters.Nome != null)
            {
                var regex = new Regex(filters.Nome, RegexOptions.IgnoreCase);
                empresasDto = empresasDto.Where(e => regex.IsMatch(e.Nome));
            }

            if (filters.CNPJ != null)
                empresasDto = empresasDto.Where(e => e.Cnpj == filters.CNPJ);

            if (filters.dtInicial != null && filters.dtFinal != null)
            {
                if (filters.DateTimeValidate())
                {
                    empresasDto = empresasDto.Where(e => e.DataFundacao >= filters.dtInicial);
                    empresasDto = empresasDto.Where(e => e.DataFundacao <= filters.dtFinal);
                }

            }
            else if (filters.dtInicial != null)
                empresasDto = empresasDto.Where(e => e.DataFundacao >= filters.dtInicial);

            else if (filters.dtFinal != null)
                empresasDto = empresasDto.Where(e => e.DataFundacao <= filters.dtFinal);

            return empresasDto;
        }


        [HttpPost]
        public IActionResult Post([FromBody] EmpresaDTO dto)
        {
            if (!_gravarService.Inserir(dto))
                return BadRequest(_gravarService.notificationContext.Notifications);

            return Created($"/api/empresa/{dto.Id}", dto);
        }




        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removerService.Remover(id))
                return BadRequest(_removerService.notificationContext.Notifications);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmpresaDTO dto)
        {
            if (!_gravarService.Alterar(id, dto))
                return BadRequest(_gravarService.notificationContext.Notifications);

            return Created($"/api/empresa/{id}", dto);
        }
    }
}
