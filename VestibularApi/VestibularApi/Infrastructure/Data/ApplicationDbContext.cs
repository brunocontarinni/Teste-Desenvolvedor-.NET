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

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Candidato>()
                .Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
