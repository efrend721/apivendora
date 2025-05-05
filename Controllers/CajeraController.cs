using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

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
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("por-caja/{numeroCaja}")]
        public async Task<ActionResult<IEnumerable<Cajera>>> GetByCaja(short numeroCaja)
        {
            var resultado = await _cajeraService.GetByCajaAsync(numeroCaja);
                if (resultado == null || resultado.Count == 0)
                    return NotFound();
                return Ok(resultado);
    }

        [HttpPost]
        public async Task<ActionResult> Create(Cajera cajera)
        {
            await _cajeraService.AddAsync(cajera);
            return StatusCode(201, cajera); // Created
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _cajeraService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
