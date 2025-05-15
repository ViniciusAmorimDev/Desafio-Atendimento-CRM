using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientePF>> GetAllAsync()
        {
            return await _context.ClientePF.ToListAsync();
        }
        public async Task<ClientePF> GetByIdAsync(int id)
        {
            return await _context.ClientePF.FindAsync(id);
        }

        public async Task<ClientePF> CreateAsync(ClientePF cliente)
        {
            _context.ClientePF.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<ClientePF> UpdateAsync(ClientePF cliente)
        {
            _context.ClientePF.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.ClientePF.FindAsync(id);
            if (cliente == null)
                return false;

            _context.ClientePF.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CpfJaCadastradoAsync(string cpf)
        {
            return await _context.ClientePF.AnyAsync(c => c.Cpf == cpf);
        }
    }
}
