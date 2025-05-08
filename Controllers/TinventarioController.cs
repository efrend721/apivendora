using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinventarioController : ControllerBase
    {
        private readonly TinventarioService _tinventarioService;

        public TinventarioController(TinventarioService tinventarioService)
        {
            _tinventarioService = tinventarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tinventario>>> GetAll()
        {
            var result = await _tinventarioService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tinventario>> GetById(int id)
        {
            var result = await _tinventarioService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el registro de inventario con ID {id}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tinventario tinventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _tinventarioService.AddAsync(tinventario);
            return StatusCode(201, tinventario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _tinventarioService.GetByIdAsync(id);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el inventario con ID {id} para eliminar."));
            }

            var deleted = await _tinventarioService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar el registro de inventario con ID {id}."));
            }

            return NoContent();
        }
    }
}
