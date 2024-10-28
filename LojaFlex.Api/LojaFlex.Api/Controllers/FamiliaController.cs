using AutoMapper;
using LojaFlex.Api.Commands;
using LojaFlex.Services.DTO;
using LojaFlex.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaFlex.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _service;
        private readonly IMapper _mapper;

        public FamiliaController(IFamiliaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os registros de famílias.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamiliaDto>>> GetEspecies()
        {
            var familias = await _service.GetAllAsync();
            return Ok(familias);
        }

        /// <summary>
        /// Obter uma família pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FamiliaDto>> GetFamilia(int id)
        {
            var familia = await _service.GetByIdAsync(id);
            if (familia == null)
            {
                return BadRequest("Família não encontrado!");
            }
            return Ok(familia);
        }

        /// <summary>
        /// Inserir um registro de família na base.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FamiliaDto>> PostFamilia([FromBody] CreateFamiliaCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var familia = _mapper.Map<FamiliaDto>(command);

            await _service.AddAsync(familia);

            return CreatedAtAction(nameof(GetFamilia), new { id = familia.IdFamilia}, familia);
        }

        /// <summary>
        /// Alterar um registro de família na base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilia(int id, [FromBody] UpdateFamiliaCommand command)
        {
            if (id != command.IdFamilia)
            {
                return BadRequest();
            }

            var familia = _mapper.Map<FamiliaDto>(command);

            var msg = await _service.UpdateAsync(familia);

            if (msg != "OK")
            {
                return BadRequest(msg);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletar uma família da base.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilia(int id)
        {
            try
            {
                var msg = await _service.DeleteAsync(id);

                if (msg != "OK")
                {
                    return BadRequest(msg);
                }

                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message.ToUpper().Contains("FOREIGN KEY CONSTRAINT"))
                    {
                        return BadRequest("Não é possível excluir esta família, pois existem registros relacionados.");
                    }
                }

                return StatusCode(500, "Ocorreu um erro ao tentar excluir a família.");
            }
        }
    }
}
