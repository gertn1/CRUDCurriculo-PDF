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
            return Ok(curriculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curriculo = await _curriculoService.GetByIdAsync(id);
            if (curriculo == null)
                return NotFound();

            return Ok(curriculo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CurriculoCreateDto curriculoDto, [FromForm] ICollection<IFormFile> files)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var curriculo = _mapper.Map<Curriculo>(curriculoDto);

            await _curriculoService.AddAsync(curriculo, files);

            var createdCurriculoDto = _mapper.Map<CurriculoDto>(curriculo);
            return CreatedAtAction(nameof(GetById), new { id = curriculo.Id }, createdCurriculoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Curriculo curriculo, [FromForm] ICollection<IFormFile> newFiles)
        {
            if (id != curriculo.Id)
                return BadRequest();

            await _curriculoService.UpdateAsync(curriculo, newFiles);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _curriculoService.DeleteAsync(id);
            return NoContent();
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
