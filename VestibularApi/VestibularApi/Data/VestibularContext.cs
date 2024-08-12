using Microsoft.EntityFrameworkCore;
using VestibularApi.Models;

namespace VestibularApi.Data
{
    public class VestibularContext : DbContext
    {
        public VestibularContext(DbContextOptions<VestibularContext> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura o relacionamento para evitar exclusão em cascata
            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Curso)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
