using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<ProcessoSeletivo> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Lead)
                .WithMany()
                .HasForeignKey(i => i.IdLead);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Oferta)
                .WithMany()
                .HasForeignKey(i => i.IdOferta);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.ProcessoSeletivo)
                .WithMany()
                .HasForeignKey(i => i.IdProcessoSeletivo);
        }
    }
}