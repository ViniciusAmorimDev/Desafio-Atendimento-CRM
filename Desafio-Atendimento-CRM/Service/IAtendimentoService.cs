using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Service
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<Atendimentos>> GetAllAsync();
        Task<Atendimentos> GetByIdAsync(int id);
        Task<Atendimentos> CreateAsync(Atendimentos cliente);
        Task<Atendimentos> UpdateAsync(int id, Atendimentos cliente);
        Task<bool> DesativarAsync(int id);
        Task<bool> AtivarAtendimentoAsync(int id);  
    }
}
