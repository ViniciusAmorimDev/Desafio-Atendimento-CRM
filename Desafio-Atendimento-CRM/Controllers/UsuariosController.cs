using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuarioService;

        public UsuariosController(IUsuariosService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter a listagem de usuários: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarioPorId(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetByIdAsync(id);
                if (usuario == null) return NotFound();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter o usuário solicitado: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuario(Usuarios usuario)
        {
            try
            {
                if (usuario == null) return NotFound("Como não foram passados os dados do usuario corretamente não foi possível cadastrar o usuário.");

                var novoUsuario = await _usuarioService.CreateAsync(usuario);
                return CreatedAtAction(nameof(GetUsuarioPorId), new { id = novoUsuario.UsuariosId }, novoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel cadastrar o usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuarios usuario)
        {
            try
            {
                var usuarioAtualizado = await _usuarioService.UpdateAsync(id, usuario);
                if (usuario == null) return NotFound();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o usuário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var deletado = await _usuarioService.DeleteAsync(id);
                if (!deletado) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel excluir o usuário solicitado: {ex.Message}");
            }
        }
    }
}
