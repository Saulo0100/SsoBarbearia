using Microsoft.EntityFrameworkCore;
using SsoBarbearia.Modelos.Entidades;

namespace SsoBarbearia.Infraestrutura.Contexto
{
    public class Contexto(DbContextOptions<Contexto> option) : DbContext(option)
    {
        public DbSet<ConfiguracaoSite> ConfiguracaoSite { get; set; }
        public DbSet<DominioAutorizado> DominioAutorizado { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);
        }
    }
}
