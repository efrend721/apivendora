using Microsoft.AspNetCore.Mvc;
using apivendora.Models.Usuarios;
using apivendora.Services.Usuarios;
using apivendora.Helpers;

namespace apivendora.Controllers.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el usuario con ID {id}."));
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            await _usuarioService.AddUsuarioAsync(usuario);

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiProblemHelper.BadRequestWithModelState(HttpContext, ModelState));
            }

            if (id != usuario.Id)
            {
                return BadRequest(ApiProblemHelper.BadRequest(HttpContext, "El ID de la URL no coincide con el ID del cuerpo de la solicitud."));
            }

            var existing = await _usuarioService.GetUsuarioByIdAsync(id);
            if (existing == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el usuario con ID {id} para actualizar."));
            }

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound(ApiProblemHelper.NotFound(HttpContext, $"No se encontró el usuario con ID {id} para eliminar."));
            }

            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
