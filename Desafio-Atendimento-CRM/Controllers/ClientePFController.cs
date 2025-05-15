using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientePFController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientePFController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientePF>>> GetClientes()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                return Ok(clientes);
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
                var cliente = await _clienteService.GetByIdAsync(id);
                if (cliente == null) return NotFound();
                return Ok(cliente);
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
                var novoCliente = await _clienteService.CreateAsync(cliente);
                return CreatedAtAction(nameof(GetClientePFId), new { id = novoCliente.ClientePfId }, novoCliente);
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
                var atualizado = await _clienteService.UpdateAsync(id, cliente);
                if (atualizado == null) return NotFound();
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o cliente PF: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientePF(int id)
        {
            try
            {
                var deletado = await _clienteService.DeleteAsync(id);
                if (!deletado) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel excluir o clientee PF: {ex.Message}");
            }
        }
    }
}
