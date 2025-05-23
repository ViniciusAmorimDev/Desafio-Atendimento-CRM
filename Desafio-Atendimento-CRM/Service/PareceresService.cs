using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Service
{
    public class PareceresService : IPareceresService
    {
        private readonly IPareceresRepository _repository;

        public PareceresService(IPareceresRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pareceres>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Pareceres> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Pareceres> CreateAsync(Pareceres parecer)
        {
            return await _repository.CreateAsync(parecer);
        }

        public async Task<Pareceres> UpdateAsync(int id, Pareceres parecer)
        {
            /*var parecerExistente = await _repository.GetByIdAsync(id);

            if (parecerExistente == null)
                throw new Exception("Parecer não encontrado.");*/

            parecer.PareceresId = id;
            return await _repository.UpdateAsync(id, parecer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parecerExistente = await _repository.GetByIdAsync(id);
            if (parecerExistente == null)
                throw new Exception("Parecer não encontrado.");

            return await _repository.DeleteAsync(id);
        }
    }
}
