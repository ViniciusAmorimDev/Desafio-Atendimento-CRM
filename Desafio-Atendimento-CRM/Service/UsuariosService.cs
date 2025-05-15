using Desafio_Atendimento_CRM.Data;
using Desafio_Atendimento_CRM.Models;
using Desafio_Atendimento_CRM.Repository;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Atendimento_CRM.Service
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repository;

        public UsuariosService(IUsuariosRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuarios> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Usuarios> CreateAsync(Usuarios usuario)
        {
            var usuarioJaCadastrado = _repository.GetUsuarioEmail(usuario.Email);
            return await _repository.CreateAsync(usuario);
        }

        public async Task<Usuarios> UpdateAsync(int id, Usuarios usuario)
        {
            var usuarioExistente = await _repository.GetByIdAsync(id);

            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado.");

            usuarioExistente.UsuariosId = id;
            return await _repository.UpdateAsync(id, usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuarioExistente = await _repository.GetByIdAsync(id);
            if (usuarioExistente == null)
                throw new Exception("Usuário não encontrado.");

            return await _repository.DeleteAsync(id);
        }
    }
}
