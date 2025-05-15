using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDbContext _context;

        public UsuariosRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<Usuarios> CreateAsync(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuarios> UpdateAsync(int id, Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Usuarios> GetUsuarioEmail(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if (usuario == null)
            {
                throw new Exception("E-mail de usuário já existente no sistema.");
            }
            return usuario;
        }
    }
}
