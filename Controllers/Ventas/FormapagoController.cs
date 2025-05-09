using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Ventas;
using apivendora.Services.Ventas;
using apivendora.Helpers;

namespace apivendora.Controllers.Ventas
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormapagoController : ControllerBase
    {
        private readonly FormapagoService _formapagoService;

        public FormapagoController(FormapagoService formapagoService)
        {
            _formapagoService = formapagoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formapago>>> GetAll()
        {
            var result = await _formapagoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{idFactura}")]
        public async Task<ActionResult<IEnumerable<Formapago>>> GetByFactura(int idFactura)
        {
            var result = await _formapagoService.GetByFacturaAsync(idFactura);

            if (result == null || !result.Any())
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontraron formas de pago para la factura con ID {idFactura}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Formapago formapago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _formapagoService.AddAsync(formapago);
            return StatusCode(201, formapago);
        }

        
    }
}
