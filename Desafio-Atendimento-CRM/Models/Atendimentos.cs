using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Atendimento_CRM.Models
{
    public class Atendimentos
    {
        [Key]
        public int AtendimentosId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        //public ClientePF Cliente { get; set; }

        public DateTime? DataAtendimento { get; set; }

        public int UsuariosId { get; set; }
        [ForeignKey("UsuariosId")]
        //public Usuarios Usuario { get; set; }

        //public ICollection<Pareceres>? Parecer { get; set; }

        public bool Status {  get; set; }

    }
}
