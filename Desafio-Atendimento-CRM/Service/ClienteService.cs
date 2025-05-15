using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientePF>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClientePF> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ClientePF> CreateAsync(ClientePF cliente)
        {
            var cpfJaCadastrado = await _repository.CpfJaCadastradoAsync(cliente.Cpf);
            if (cpfJaCadastrado)
            {
                throw new InvalidOperationException("CPF já cadastrado no sistema, por favor verifique.");
            }
            return await _repository.CreateAsync(cliente);
        }

        public async Task<ClientePF> UpdateAsync(int id, ClientePF cliente)
        {
            var clienteExistente = await _repository.GetByIdAsync(id);

            if (clienteExistente == null)
                throw new InvalidOperationException("ClientePF não encontrado.");

            cliente.ClientePfId = id;
            return await _repository.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var clienteExistente = await _repository.GetByIdAsync(id);
            if (clienteExistente == null) 
                throw new InvalidOperationException("ClientePF não encontrado.");

            return await _repository.DeleteAsync(id);
        }

    }
}
