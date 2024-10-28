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
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;
        private readonly IMapper _mapper;

        public PaisController(IPaisService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os registros de país.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetPaises()
        {
            var paises = await _service.GetAllAsync();
            return Ok(paises);
        }

        /// <summary>
        /// Obter um país pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> GetPais(int id)
        {
            var pais = await _service.GetByIdAsync(id);
            if (pais == null)
            {
                return BadRequest("País não encontrado!");
            }
            return Ok(pais);
        }

        /// <summary>
        /// Inserir um registro de país na base.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PaisDto>> PostPais([FromBody] CreatePaisCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pais = _mapper.Map<PaisDto>(command);

            await _service.AddAsync(pais);

            return CreatedAtAction(nameof(GetPais), new { id = pais.IdPais }, pais);
        }

        /// <summary>
        /// Alterar um registro de país na base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, [FromBody] UpdatePaisCommand command)
        {
            if (id != command.IdPais)
            {
                return BadRequest();
            }

            var pais = _mapper.Map<PaisDto>(command);

            var msg = await _service.UpdateAsync(pais);

            if (msg != "OK")
            {
                return BadRequest(msg);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletar um país da base.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
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
                        return BadRequest("Não é possível excluir este país, pois existem registros relacionados.");
                    }
                }

                return StatusCode(500, "Ocorreu um erro ao tentar excluir o país.");
            }
        }
    }
}
