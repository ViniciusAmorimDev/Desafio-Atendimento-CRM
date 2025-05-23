using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Service
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentosRepository _repository;

        public AtendimentoService(IAtendimentosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Atendimentos>> GetAllAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Atendimentos> GetByIdAsync(int id)
            {
                return await _repository.GetByIdAsync(id);
            }

            public async Task<Atendimentos> CreateAsync(Atendimentos atendimento)
            {
                return await _repository.CreateAsync(atendimento);
            }

            public async Task<Atendimentos> UpdateAsync(int id, Atendimentos atendimento)
            {
                var AtendimentoExistente = await _repository.GetByIdAsync(id);
                if (AtendimentoExistente == null)
                {
                    throw new ArgumentException("Id do Atendimento não encontrado");
                }
                return await _repository.UpdateAsync(id, atendimento);
        }

            public async Task<bool> DesativarAsync(int id)
            {
                var AtendimentoExistente = await _repository.GetByIdAsync(id);
                if (AtendimentoExistente == null)
                {
                    throw new ArgumentException("Id do Atendimento não encontrado");
                }

                var AtendimentoDesativado = await _repository.DesativarAtendimentoAsync(id);
                if (AtendimentoDesativado)
                {
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("O atendimento foi encontrado porém não foi possível ser desativado.");
                }
            }

            public async Task<bool> AtivarAtendimentoAsync(int id)
            {
                var AtendimentoExistente = await _repository.GetByIdAsync(id);
                if (AtendimentoExistente == null)
                {
                    throw new ArgumentException("Id do Atendimento não encontrado");
                }

                var AtendimentoAtivado = await AtivarAtendimentoAsync(id);
                if (AtendimentoAtivado)
                {
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("O atendimento foi encontrado porém não foi possível ser ativado.");
                }
        }
    }
}
