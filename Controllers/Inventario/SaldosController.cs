using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Inventario;
using apivendora.Services.Inventario;
using apivendora.Helpers;

namespace apivendora.Controllers.Inventario
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaldosController : ControllerBase
    {
        private readonly SaldosService _saldosService;

        public SaldosController(SaldosService saldosService)
        {
            _saldosService = saldosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saldos>>> GetAll()
        {
            var result = await _saldosService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{cdgoProducto}")]
        public async Task<ActionResult<Saldos>> GetById(int cdgoProducto)
        {
            var result = await _saldosService.GetByIdAsync(cdgoProducto);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró saldo para el producto con código {cdgoProducto}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Saldos saldos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _saldosService.AddAsync(saldos);
            return StatusCode(201, saldos);
        }

        [HttpDelete("{cdgoProducto}")]
        public async Task<ActionResult> Delete(int cdgoProducto)
        {
            var exists = await _saldosService.GetByIdAsync(cdgoProducto);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el saldo para el producto con código {cdgoProducto} para eliminar."));
            }

            var deleted = await _saldosService.DeleteAsync(cdgoProducto);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar el saldo para el producto con código {cdgoProducto}."));
            }

            return NoContent();
        }
    }
}
