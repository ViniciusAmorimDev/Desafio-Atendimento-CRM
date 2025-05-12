using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Desafio_Atendimento_CRM.Models
{
    public class ClientePF
    {
        [Key]
        public int? ClientePfId {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public bool Status {  get; set; }

        public int? AtendimentosId { get; set; }


    }
}
