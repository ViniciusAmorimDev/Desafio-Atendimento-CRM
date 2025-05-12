using System.ComponentModel.DataAnnotations;

namespace Desafio_Atendimento_CRM.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuariosId { get; set; }
        public string Nome {  get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}
