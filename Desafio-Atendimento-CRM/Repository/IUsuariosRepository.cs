using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Repository
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios> GetByIdAsync(int id);
        Task<Usuarios> CreateAsync(Usuarios usuario);
        Task<Usuarios> UpdateAsync(int id, Usuarios usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuarios> GetUsuarioEmail(string email);
    }
}
