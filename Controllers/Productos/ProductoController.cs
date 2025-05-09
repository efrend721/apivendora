using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Productos;
using apivendora.Services.Productos;
using apivendora.Helpers;

namespace apivendora.Controllers.Productos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            var result = await _productoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{cdgo}")]
        public async Task<ActionResult<Producto>> GetById(int cdgo)
        {
            var result = await _productoService.GetByIdAsync(cdgo);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el producto con código {cdgo}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _productoService.AddAsync(producto);
            return StatusCode(201, producto);
        }

        [HttpDelete("{cdgo}")]
        public async Task<ActionResult> Delete(int cdgo)
        {
            var exists = await _productoService.GetByIdAsync(cdgo);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el producto con código {cdgo} para eliminar."));
            }

            var deleted = await _productoService.DeleteAsync(cdgo);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar el producto con código {cdgo}."));
            }

            return NoContent();
        }
    }
}
