using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MtransaccionController : ControllerBase
    {
        private readonly MtransaccionService _mtransaccionService;

        public MtransaccionController(MtransaccionService mtransaccionService)
        {
            _mtransaccionService = mtransaccionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mtransaccion>>> GetAll()
        {
            var result = await _mtransaccionService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Mtransaccion>> GetById(string codigo)
        {
            var result = await _mtransaccionService.GetByIdAsync(codigo);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la transacción con código '{codigo}'."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Mtransaccion transaccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _mtransaccionService.AddAsync(transaccion);
            return StatusCode(201, transaccion);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(string codigo)
        {
            var exists = await _mtransaccionService.GetByIdAsync(codigo);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la transacción con código '{codigo}' para eliminar."));
            }

            var deleted = await _mtransaccionService.DeleteAsync(codigo);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar la transacción con código '{codigo}'."));
            }

            return NoContent();
        }
    }
}
