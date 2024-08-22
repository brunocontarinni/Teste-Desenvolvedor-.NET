using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;

namespace VestibularApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CandidatoEntities> Candidatos { get; set; }
        public DbSet<InscricaoEntities> Inscricoes { get; set; }
        public DbSet<OfertaEntities> Ofertas { get; set; }
        public DbSet<ProcessoSeletivoEntities> ProcessosSeletivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CandidatoEntities>()
                .Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<InscricaoEntities>()
                .Property(i => i.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<OfertaEntities>()
                .Property(o => o.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ProcessoSeletivoEntities>()
                .Property(l => l.Id)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
