using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Ventas;
using apivendora.Services.Ventas;
using apivendora.Helpers;

namespace apivendora.Controllers.Ventas
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

            if (result == null || !result.Any())
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontraron impuestos para la factura con ID {idFactura}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Impuesto impuesto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _impuestoService.AddAsync(impuesto);
            return StatusCode(201, impuesto);
        }

       
    }
}
