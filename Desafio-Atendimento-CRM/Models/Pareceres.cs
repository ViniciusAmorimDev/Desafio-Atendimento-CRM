using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Atendimento_CRM.Models
{
    public class Pareceres
    {
        [Key]
        public int PareceresId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int AtendimentosId { get; set; } 
        [ForeignKey("AtendimentosId")]
        //public Atendimentos Atendimento { get; set; }
        
        public int UsuariosId { get; set; }
        [ForeignKey("UsuariosId")]

        public bool Status { get; set; }
        //public Usuarios Usuario { get; set; }
    }
}
