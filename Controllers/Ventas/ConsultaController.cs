using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Ventas;
using apivendora.Services.Ventas;
using apivendora.Helpers;

namespace apivendora.Controllers.Ventas
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaController : ControllerBase
    {
        private readonly ConsultaService _consultaService;

        public ConsultaController(ConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetAll()
        {
            var result = await _consultaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> GetById(int id)
        {
            var result = await _consultaService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la consulta con ID {id}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _consultaService.AddAsync(consulta);
            return StatusCode(201, consulta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var consulta = await _consultaService.GetByIdAsync(id);

            if (consulta == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la consulta con ID {id} para eliminar."));
            }

            var deleted = await _consultaService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar la consulta con ID {id}."));
            }

            return NoContent();
        }
    }
}
