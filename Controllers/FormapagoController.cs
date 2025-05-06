using Microsoft.AspNetCore.Mvc;
using apivendora.Models;
using apivendora.Services;

namespace apivendora.Controllers
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
            if (result == null || result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Formapago formapago)
        {
            await _formapagoService.AddAsync(formapago);
            return StatusCode(201, formapago);
        }
    }
}
