using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CajeraController : ControllerBase
    {
        private readonly CajeraService _cajeraService;

        public CajeraController(CajeraService cajeraService)
        {
            _cajeraService = cajeraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajera>>> GetAll()
        {
            var result = await _cajeraService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cajera>> GetById(int id)
        {
            var result = await _cajeraService.GetByIdAsync(id);

            if (result == null) 
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la cajera con ID {id}."));
            }

            return Ok(result);
        }

        [HttpGet("por-caja/{numeroCaja}")]
        public async Task<ActionResult<IEnumerable<Cajera>>> GetByCaja(short numeroCaja)
        {
            var resultado = await _cajeraService.GetByCajaAsync(numeroCaja);

            if (resultado == null || resultado.Count == 0)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontraron cajeras asignadas a la caja número {numeroCaja}."));
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cajera cajera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _cajeraService.AddAsync(cajera);
            return StatusCode(201, cajera);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cajera = await _cajeraService.GetByIdAsync(id);

            if (cajera == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la cajera con ID {id} para eliminar."));
            }

            var deleted = await _cajeraService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"La cajera con ID {id} no se pudo eliminar."));
            }

            return NoContent();
        }
    }
}

