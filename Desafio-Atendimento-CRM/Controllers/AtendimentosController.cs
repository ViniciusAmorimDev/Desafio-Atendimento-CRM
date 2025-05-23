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
    public class AtendimentosController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentosController(IAtendimentoService atendimentosService)
        {
            _atendimentoService = atendimentosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimentos>>> GetAtendimentos()
        {
            try
            {
                var atendimentos = await _atendimentoService.GetAllAsync();
                return Ok(atendimentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter a listagem de Atendimentos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimentos>> GetAtendimentoPorId(int id)
        {
            try
            {
                var atendimento = await _atendimentoService.GetByIdAsync(id);
                if (atendimento == null) return NotFound();
                return Ok(atendimento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter o clientee PF: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Atendimentos>> PostAtendimento(Atendimentos atendimento)
        {
            try
            {
                if (atendimento == null) return NotFound("Como não foram passados os dados do atendimento corretamente não foi possivel incluir o novo atendimento.");

                var novoAtendimento = await _atendimentoService.CreateAsync(atendimento);
                return CreatedAtAction(nameof(GetAtendimentoPorId), new { id = novoAtendimento.AtendimentosId }, novoAtendimento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel incluir o novo atendimento: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, Atendimentos atendimento)
        {
            try
            {
                if (id != atendimento.AtendimentosId) return BadRequest();

                var atualizado = await _atendimentoService.UpdateAsync(id, atendimento);
                if (atualizado == null) return NotFound();
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o atendimento solicitado: {ex.Message}");
            }
        }

        [HttpPut("ativa/{id}")]
        public async Task<IActionResult> AtivaAtendimentoId(int id)
        {
            try
            {
                var atendimentoParaAtivar = await _atendimentoService.AtivarAtendimentoAsync(id);
                if (!atendimentoParaAtivar) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel excluir o atendimento solicitado: {ex.Message}");
            }
        }

        [HttpPut("inativa/{id}")]
        public async Task<IActionResult> DesativarAtendimentoId(int id)
        {
            try
            {
                var atualizado = await _atendimentoService.DesativarAsync(id);
                if (atualizado == null) return NotFound();
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o atendimento solicitado: {ex.Message}");
            }
        }
    }
}
