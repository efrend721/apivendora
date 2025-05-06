using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

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
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Mformapago mformapago)
        {
            await _mformapagoService.AddAsync(mformapago);
            return StatusCode(201, mformapago);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _mformapagoService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
