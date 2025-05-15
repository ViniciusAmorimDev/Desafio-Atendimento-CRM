using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Repository
{
    public class PareceresRepository : IPareceresRepository
    {
        private readonly AppDbContext _context;

        public PareceresRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pareceres>> GetAllAsync()
        {
            return await _context.Pareceres.ToListAsync();
        }
        public async Task<Pareceres> GetByIdAsync(int id)
        {
            return await _context.Pareceres.FindAsync(id);
        }
        public async Task<Pareceres> CreateAsync(Pareceres parecer)
        {
            _context.Pareceres.Add(parecer);
            await _context.SaveChangesAsync();
            return parecer;
        }
        public async Task<Pareceres> UpdateAsync(int id, Pareceres parecer)
        {
            _context.Pareceres.Update(parecer);
            await _context.SaveChangesAsync();
            return parecer;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var parecer = await _context.Pareceres.FindAsync(id);
            if (parecer == null)
                throw new Exception("Parecer não encontrado no sistema.");

            _context.Pareceres.Remove(parecer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
