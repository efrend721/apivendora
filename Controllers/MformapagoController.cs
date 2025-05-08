using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;
using apivendora.Helpers;

namespace apivendora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MformapagoController : ControllerBase
    {
        private readonly MformapagoService _mformapagoService;

        public MformapagoController(MformapagoService mformapagoService)
        {
            _mformapagoService = mformapagoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mformapago>>> GetAll()
        {
            var result = await _mformapagoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mformapago>> GetById(int id)
        {
            var result = await _mformapagoService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la forma de pago con ID {id}."));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Mformapago mformapago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _mformapagoService.AddAsync(mformapago);
            return StatusCode(201, mformapago);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _mformapagoService.GetByIdAsync(id);

            if (exists == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró la forma de pago con ID {id} para eliminar."));
            }

            var deleted = await _mformapagoService.DeleteAsync(id);

            if (!deleted)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, $"No se pudo eliminar la forma de pago con ID {id}."));
            }

            return NoContent();
        }
    }
}
