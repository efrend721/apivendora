using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Productos;
using apivendora.Services.Productos;
using apivendora.Helpers;

namespace apivendora.Controllers.Productos
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarrasController : ControllerBase
    {
        private readonly BarrasService _barrasService;

        public BarrasController(BarrasService barrasService)
        {
            _barrasService = barrasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barras>>> GetAll()
        {
            var result = await _barrasService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{cdgoBarra}")]
        public async Task<ActionResult<Barras>> GetById(string cdgoBarra)
        {
            var result = await _barrasService.GetByIdAsync(cdgoBarra);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el recurso con cdgoBarra: {cdgoBarra}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Barras barra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _barrasService.AddAsync(barra);
            return StatusCode(201, barra);
        }

        [HttpDelete("{cdgoBarra}")]
        public async Task<ActionResult> Delete(string cdgoBarra)
        {
            var deleted = await _barrasService.DeleteAsync(cdgoBarra);

            if (!deleted)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se pudo eliminar. No se encontró el recurso con cdgoBarra: {cdgoBarra}."));
            }

            return NoContent();
        }
    }
}
