using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TinventarioController : ControllerBase
    {
        private readonly TinventarioService _service;

        public TinventarioController(TinventarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tinventario>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tinventario>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Tinventario item)
        {
            await _service.AddAsync(item);
            return StatusCode(201, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
