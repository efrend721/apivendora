using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
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
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Barras barra)
        {
            await _barrasService.AddAsync(barra);
            return StatusCode(201, barra); // Created
        }

        [HttpDelete("{cdgoBarra}")]
        public async Task<ActionResult> Delete(string cdgoBarra)
        {
            var deleted = await _barrasService.DeleteAsync(cdgoBarra);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
