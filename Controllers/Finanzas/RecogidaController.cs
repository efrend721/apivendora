using Microsoft.AspNetCore.Mvc;
using apivendora.Helpers;
using apivendora.Services.Finanzas;
using apivendora.Models.Finanzas;

namespace apivendora.Controllers.Finanzas
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecogidaController : ControllerBase
    {
        private readonly RecogidaService _recogidaService;

        public RecogidaController(RecogidaService recogidaService)
        {
            _recogidaService = recogidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recogida>>> GetAll()
        {
            var result = await _recogidaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recogida>> GetById(int id)
        {
            var result = await _recogidaService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la recogida con ID {id}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recogida recogida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _recogidaService.AddAsync(recogida);
            return StatusCode(201, recogida);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _recogidaService.GetByIdAsync(id);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la recogida con ID {id} para eliminar."));
            }

            var deleted = await _recogidaService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar la recogida con ID {id}."));
            }

            return NoContent();
        }
    }
}
