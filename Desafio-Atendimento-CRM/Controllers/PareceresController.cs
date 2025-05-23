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
    public class PareceresController : ControllerBase
    {
        private readonly IPareceresService _parecerService;

        public PareceresController(IPareceresService parecerService)
        {
            _parecerService = parecerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pareceres>>> GetPareceres()
        {
            try
            {
                var pareceres = await _parecerService.GetAllAsync();
                return Ok(pareceres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter a listagem de Pareceres: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pareceres>> GetParecerPorId(int id)
        {
            try
            {
                var parecer = await _parecerService.GetByIdAsync(id);
                if (parecer == null) return NotFound();
                return Ok(parecer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter o parecer solicitado: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pareceres>> PostParecer(Pareceres parecer)
        {
            try
            {
                if (parecer == null) return NotFound("Como não foi passado os dados do parecer corretamente não foi possivel cadastrar o novo parecer solicitado.");

                var novoParecer = await _parecerService.CreateAsync(parecer);
                return CreatedAtAction(nameof(GetParecerPorId), new { id = novoParecer.PareceresId }, novoParecer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel cadastrar o parecer solicitado: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParecer(int id, Pareceres parecer)
        {
            try
            {
                var atualizado = await _parecerService.UpdateAsync(id, parecer);
                if (atualizado == null) return NotFound();
                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel editar o parecer solicitado: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParecer(int id)
        {
            try
            {
                var parecer = await _parecerService.GetByIdAsync(id);
                if (parecer == null) return NotFound();

                var deletado = await _parecerService.DeleteAsync(id);
                if (!deletado) return NotFound();
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel excluir o parecer solicitado: {ex.Message}");
            }
        }
    }
}
