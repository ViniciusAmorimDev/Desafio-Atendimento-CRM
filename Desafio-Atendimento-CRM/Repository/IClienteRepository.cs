using Desafio_Atendimento_CRM.Models;
namespace Desafio_Atendimento_CRM.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClientePF>> GetAllAsync();
        Task<ClientePF> GetByIdAsync(int id);
        Task<ClientePF> CreateAsync(ClientePF cliente);
        Task<ClientePF> UpdateAsync(ClientePF cliente);
        Task<bool> DeleteAsync(int id);
        Task<bool> CpfJaCadastradoAsync(string cpf);
    }
}
