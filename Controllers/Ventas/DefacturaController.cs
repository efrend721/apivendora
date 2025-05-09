using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Ventas;
using apivendora.Services.Ventas;
using apivendora.Helpers;

namespace apivendora.Controllers.Ventas
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefacturaController : ControllerBase
    {
        private readonly DefacturaService _defacturaService;

        public DefacturaController(DefacturaService defacturaService)
        {
            _defacturaService = defacturaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Defactura>>> GetAll()
        {
            var result = await _defacturaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{idFactura}")]
        public async Task<ActionResult<IEnumerable<Defactura>>> GetByFactura(int idFactura)
        {
            var result = await _defacturaService.GetByFacturaAsync(idFactura);

            if (result == null || !result.Any())
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontraron registros de detalle para la factura con ID {idFactura}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Defactura defactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _defacturaService.AddAsync(defactura);
            return StatusCode(201, defactura);
        }

        
    }
}
