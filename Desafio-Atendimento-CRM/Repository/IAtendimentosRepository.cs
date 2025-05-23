using Desafio_Atendimento_CRM.Models;

namespace Desafio_Atendimento_CRM.Repository
{
    public interface IAtendimentosRepository
    {
        Task<IEnumerable<Atendimentos>> GetAllAsync();
        Task<Atendimentos> GetByIdAsync(int id);
        Task<Atendimentos> CreateAsync(Atendimentos atendimento);
        Task<Atendimentos> UpdateAsync(int id, Atendimentos atendimento);
        Task<bool> DesativarAtendimentoAsync(int id);
        Task<bool> AtivarAtendimentoAsync(int id);
    }
}
