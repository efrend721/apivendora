using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
        {
            var result = await _facturaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{idFactura}")]
        public async Task<ActionResult<Factura>> GetById(int idFactura)
        {
            var result = await _facturaService.GetByIdAsync(idFactura);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Factura factura)
        {
            await _facturaService.AddAsync(factura);
            return StatusCode(201, factura);
        }

        [HttpDelete("{idFactura}")]
        public async Task<ActionResult> Delete(int idFactura)
        {
            var deleted = await _facturaService.DeleteAsync(idFactura);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
