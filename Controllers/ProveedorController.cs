using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetAll()
        {
            var result = await _proveedorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetById(string id)
        {
            var result = await _proveedorService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el proveedor con ID '{id}'."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _proveedorService.AddAsync(proveedor);
            return StatusCode(201, proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exists = await _proveedorService.GetByIdAsync(id);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el proveedor con ID '{id}' para eliminar."));
            }

            var deleted = await _proveedorService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar el proveedor con ID '{id}'."));
            }

            return NoContent();
        }
    }
}
