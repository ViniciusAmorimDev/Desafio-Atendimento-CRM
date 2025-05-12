using Desafio_Atendimento_CRM.Models;
using Microsoft.EntityFrameworkCore;
namespace Desafio_Atendimento_CRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ClientePF> ClientePF { get; set; }
        public DbSet<Atendimentos> Atendimentos { get; set; }
        public DbSet<Pareceres> Pareceres { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
