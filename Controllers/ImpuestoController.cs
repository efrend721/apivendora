using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImpuestoController : ControllerBase
    {
        private readonly ImpuestoService _impuestoService;

        public ImpuestoController(ImpuestoService impuestoService)
        {
            _impuestoService = impuestoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Impuesto>>> GetAll()
        {
            var result = await _impuestoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{idFactura}")]
        public async Task<ActionResult<IEnumerable<Impuesto>>> GetByFactura(int idFactura)
        {
            var result = await _impuestoService.GetByFacturaAsync(idFactura);
            if (result == null || result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Impuesto impuesto)
        {
            await _impuestoService.AddAsync(impuesto);
            return StatusCode(201, impuesto);
        }
    }
}
