using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
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
            if (result == null || result.Count == 0) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Defactura defactura)
        {
            await _defacturaService.AddAsync(defactura);
            return StatusCode(201, defactura);
        }
    }
}
