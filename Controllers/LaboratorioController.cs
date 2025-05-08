using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratorioController : ControllerBase
    {
        private readonly LaboratorioService _laboratorioService;

        public LaboratorioController(LaboratorioService laboratorioService)
        {
            _laboratorioService = laboratorioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laboratorio>>> GetAll()
        {
            var result = await _laboratorioService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Laboratorio>> GetById(int id)
        {
            var result = await _laboratorioService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el laboratorio con código {id}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Laboratorio laboratorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _laboratorioService.AddAsync(laboratorio);
            return StatusCode(201, laboratorio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _laboratorioService.GetByIdAsync(id);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el laboratorio con código {id} para eliminar."));
            }

            var deleted = await _laboratorioService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar el laboratorio con código {id}."));
            }

            return NoContent();
        }
    }
}
