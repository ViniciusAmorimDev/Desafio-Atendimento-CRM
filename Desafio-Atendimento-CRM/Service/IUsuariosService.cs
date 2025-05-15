using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Service
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios> GetByIdAsync(int id);
        Task<Usuarios> CreateAsync(Usuarios usuario);
        Task<Usuarios> UpdateAsync(int id, Usuarios usuario);
        Task<bool> DeleteAsync(int id);
    }
}
