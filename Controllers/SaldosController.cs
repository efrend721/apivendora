using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaldosController : ControllerBase
    {
        private readonly SaldosService _service;

        public SaldosController(SaldosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saldos>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{cdgoProducto}")]
        public async Task<ActionResult<Saldos>> GetById(int cdgoProducto)
        {
            var result = await _service.GetByIdAsync(cdgoProducto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Saldos saldo)
        {
            await _service.AddAsync(saldo);
            return StatusCode(201, saldo);
        }

        [HttpDelete("{cdgoProducto}")]
        public async Task<ActionResult> Delete(int cdgoProducto)
        {
            var deleted = await _service.DeleteAsync(cdgoProducto);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
