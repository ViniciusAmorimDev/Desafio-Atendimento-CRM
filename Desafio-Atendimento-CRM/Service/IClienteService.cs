using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Service
{
    public interface IClienteService
    {
        Task<IEnumerable<ClientePF>> GetAllAsync();
        Task<ClientePF> GetByIdAsync(int id);
        Task<ClientePF> CreateAsync(ClientePF cliente);
        Task<ClientePF> UpdateAsync(int id, ClientePF cliente);
        Task<bool> DeleteAsync(int id);
    }
}
