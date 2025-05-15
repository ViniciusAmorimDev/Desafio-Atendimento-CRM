using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Repository
{
    public interface IPareceresRepository
    {
        Task<IEnumerable<Pareceres>> GetAllAsync();
        Task<Pareceres> GetByIdAsync(int id);
        Task<Pareceres> CreateAsync(Pareceres parecer);
        Task<Pareceres> UpdateAsync(int id, Pareceres parecer);
        Task<bool> DeleteAsync(int id);
    }
}
