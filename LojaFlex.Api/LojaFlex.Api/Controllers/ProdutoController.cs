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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os registros de produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetEspecies()
        {
            var produtos = await _service.GetAllAsync();
            return Ok(produtos);
        }

        /// <summary>
        /// Obter uma produto pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> GetProduto(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            
            if (produto == null)
            {
                return BadRequest("Produto não encontrado!");
            }

            return Ok(produto);
        }

        /// <summary>
        /// Inserir um registro de produto na base.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> PostProduto([FromBody] CreateProdutoCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = _mapper.Map<ProdutoDto>(command);

            await _service.AddAsync(produto);

            return CreatedAtAction(nameof(GetProduto), new { id = produto.IdProduto }, produto);
        }

        /// <summary>
        /// Alterar um registro de produto na base.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, [FromBody] UpdateProdutoCommand command)
        {
            if (id != command.IdFamilia)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<ProdutoDto>(command);

            var msg = await _service.UpdateAsync(produto);

            if (msg != "OK")
            {
                return BadRequest(msg);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletar uma produto da base.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
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
                        return BadRequest("Não é possível excluir este produto, pois existem registros relacionados.");
                    }
                }

                return StatusCode(500, "Ocorreu um erro ao tentar excluir o produto.");
            }
        }
    }
}
