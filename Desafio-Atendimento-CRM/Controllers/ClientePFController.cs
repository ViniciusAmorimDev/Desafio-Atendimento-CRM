using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientePFController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientePFController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientePF>>> GetClientes()
        {
            try
            {
                return await _context.ClientePF.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter a listagem de clientes PF: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientePF>> GetClientePFId(int id)
        {
            try
            {
                var cliente = await _context.ClientePF
                  .FirstOrDefaultAsync(c => c.ClientePfId == id);
                if (cliente == null) return NotFound();
                return cliente;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter o clientee PF: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientePF>> PostClientePF(ClientePF cliente)
        {
            try
            {
                if (cliente == null) return NotFound("Como não passado os dados do cliente corretamente não foi possivel cadastrar o clientee PF");
                
                /*var clientebanco = await _context.ClientePF
                    .FirstOrDefaultAsync(c => c.Nome == cliente.Nome);
                if (cliente.Nome == clientebanco.Nome) return NotFound();*/
;
                _context.ClientePF.Add(cliente);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetClientePFId), new { id = cliente.ClientePfId }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel cadastrar o clientee PF: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientePF(int id, ClientePF cliente)
        {
            try
            {
                if (id != cliente.ClientePfId) return BadRequest();

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o clientee PF: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientePF(int id)
        {
            try
            {
                var cliente = await _context.ClientePF.FindAsync(id);
                if (cliente == null) return NotFound();

                _context.ClientePF.Remove(cliente);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel excluir o clientee PF: {ex.Message}");
            }
        }
    }
}
