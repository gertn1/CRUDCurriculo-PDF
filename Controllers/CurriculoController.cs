using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCurriculum.DTOs;
using WebCurriculum.Enums;
using WebCurriculum.Interface.Service;

namespace WebCurriculum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculoController : ControllerBase
    {
        private readonly ICurriculoService _curriculoService;
        private readonly IMapper _mapper;

        public CurriculoController(ICurriculoService curriculoService, IMapper mapper)
        {
            _curriculoService = curriculoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var curriculos = await _curriculoService.GetAllAsync();
            var curriculosDto = _mapper.Map<IEnumerable<CurriculoDto>>(curriculos);
            return Ok(curriculosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curriculo = await _curriculoService.GetByIdAsync(id);
            if (curriculo == null)
                return NotFound();

            var curriculoDto = _mapper.Map<CurriculoDto>(curriculo);
            return Ok(curriculoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CurriculoCreateDto curriculoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var curriculo = _mapper.Map<Curriculo>(curriculoDto);

            await _curriculoService.AddAsync(curriculo, curriculoDto.File);

            var createdCurriculoDto = _mapper.Map<CurriculoDto>(curriculo);
            return CreatedAtAction(nameof(GetById), new { id = curriculo.Id }, createdCurriculoDto);
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string nome, [FromQuery] Nivel? nivel)
        {
            var curriculos = await _curriculoService.GetAllAsync();

            if (!string.IsNullOrEmpty(nome))
            {
                curriculos = curriculos.Where(c => c.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
            }

            if (nivel.HasValue)
            {
                curriculos = curriculos.Where(c => c.Nivel == nivel.Value);
            }

            return Ok(curriculos);
        }
    }
}
