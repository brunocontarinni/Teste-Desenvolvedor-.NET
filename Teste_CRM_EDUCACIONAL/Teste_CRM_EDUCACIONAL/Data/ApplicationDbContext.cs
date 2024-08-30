using Microsoft.EntityFrameworkCore;
using Teste_CRM_EDUCACIONAL.Models;

namespace Teste_CRM_EDUCACIONAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAFAEL\\MSSQLSERVER01;Database=CRM_Educacional;Trusted_Connection=True;",
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.HasIndex(l => l.CPF).IsUnique();
                entity.HasMany(l => l.Inscricoes)      
                      .WithOne(i => i.Lead)
                      .HasForeignKey(i => i.LeadId);
            });

            modelBuilder.Entity<ProcessoSeletivo>(entity =>
            {
                entity.HasMany(ps => ps.Inscricoes) 
                      .WithOne(i => i.ProcessoSeletivo)
                      .HasForeignKey(i => i.ProcessoSeletivoId);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasMany(o => o.Inscricoes) 
                      .WithOne(i => i.Oferta)
                      .HasForeignKey(i => i.OfertaId);
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasOne(i => i.Lead) 
                      .WithMany(l => l.Inscricoes)
                      .HasForeignKey(i => i.LeadId);

                entity.HasOne(i => i.ProcessoSeletivo) 
                      .WithMany(ps => ps.Inscricoes)
                      .HasForeignKey(i => i.ProcessoSeletivoId);

                entity.HasOne(i => i.Oferta) 
                      .WithMany(o => o.Inscricoes)
                      .HasForeignKey(i => i.OfertaId);
            });
        }
    }
}
