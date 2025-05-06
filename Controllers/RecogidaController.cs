using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
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
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recogida recogida)
        {
            await _recogidaService.AddAsync(recogida);
            return StatusCode(201, recogida);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _recogidaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
