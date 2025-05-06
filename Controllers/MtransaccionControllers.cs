using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MtransaccionController : ControllerBase
    {
        private readonly MtransaccionService _service;

        public MtransaccionController(MtransaccionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mtransaccion>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Mtransaccion>> GetById(string codigo)
        {
            var result = await _service.GetByIdAsync(codigo);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Mtransaccion transaccion)
        {
            await _service.AddAsync(transaccion);
            return StatusCode(201, transaccion);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(string codigo)
        {
            var deleted = await _service.DeleteAsync(codigo);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
