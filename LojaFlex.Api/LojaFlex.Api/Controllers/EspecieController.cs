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
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieService _service;
        private readonly IMapper _mapper;

        public EspecieController(IEspecieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os registros de espécies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecieDto>>> GetEspecies()
        {
            var especies = await _service.GetAllAsync();
            return Ok(especies);
        }

        /// <summary>
        /// Obter uma espécie pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecieDto>> GetEspecie(int id)
        {
            var autor = await _service.GetByIdAsync(id);
            if (autor == null)
            {
                return BadRequest("Espécie não encontrado!");
            }
            return Ok(autor);
        }

        /// <summary>
        /// Inserir um registro de espécie na base.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EspecieDto>> PostEspecie([FromBody] CreateEspecieCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var especie = _mapper.Map<EspecieDto>(command);

            await _service.AddAsync(especie);

            return CreatedAtAction(nameof(GetEspecie), new { id = especie.IdEspecie }, especie);
        }

        /// <summary>
        /// Alterar um registro de espécie na base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecie(int id, [FromBody] UpdateEspecieCommand command)
        {
            if (id != command.IdEspecie)
            {
                return BadRequest();
            }

            var especie = _mapper.Map<EspecieDto>(command);

            var msg = await _service.UpdateAsync(especie);

            if (msg != "OK")
            {
                return BadRequest(msg);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletar uma espécie da base.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecie(int id)
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
                        return BadRequest("Não é possível excluir esta espécie, pois existem registros relacionados.");
                    }
                }

                return StatusCode(500, "Ocorreu um erro ao tentar excluir a espécie.");
            }
        }
    }
}
