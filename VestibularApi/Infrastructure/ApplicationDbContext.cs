using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;

namespace VestibularApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProcessoSeletivo>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Lead>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Oferta>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Inscricao>()
                .HasKey(i => i.Id);


            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Lead)
                .WithMany(l => l.Inscricoes)
                .HasForeignKey(i => i.LeadId);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.ProcessoSeletivo)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(i => i.ProcessoSeletivoId);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Oferta)
                .WithMany(o => o.Inscricoes)
                .HasForeignKey(i => i.OfertaId);
        }
    }
}