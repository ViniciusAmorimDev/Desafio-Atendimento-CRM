using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Repository
{
    public class AtendimentosRepository : IAtendimentosRepository
    {
        private readonly AppDbContext _context;

        public AtendimentosRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Atendimentos>> GetAllAsync()
        {
            return await _context.Atendimentos.ToListAsync();
        }
        public async Task<Atendimentos> GetByIdAsync(int id)
        {
            return await _context.Atendimentos.FindAsync(id);
        }
        public async Task<Atendimentos> CreateAsync(Atendimentos atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();
            return atendimento;
        }
        public async Task<Atendimentos> UpdateAsync(int id, Atendimentos atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            await _context.SaveChangesAsync();
            return atendimento;
        }
        public async Task<bool> DesativarAtendimentoAsync(int id)
        {
            var atendimento = await _context.Atendimentos.FirstOrDefaultAsync(x => x.AtendimentosId == id);
            atendimento.Status = false;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AtivarAtendimentoAsync (int id)
        {
            var atendimento = await _context.Atendimentos.FirstOrDefaultAsync(x => x.AtendimentosId == id);
            atendimento.Status = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
