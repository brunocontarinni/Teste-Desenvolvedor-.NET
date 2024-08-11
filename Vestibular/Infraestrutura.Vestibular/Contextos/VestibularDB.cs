using Microsoft.EntityFrameworkCore;
using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Contextos
{
    public class VestibularDB : DbContext
    {
        #region Propriedades
        public DbSet<Oferta> Ofertas { get; set; }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<ProcessoSeletivo> ProcessoSeletivos { get; set; }

        public DbSet<Inscricao> Inscricoes { get; set; }
        #endregion

        public VestibularDB(DbContextOptions<VestibularDB> options) : base(options) { }        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inscricao>()
                        .HasOne<Oferta>(i => i.Oferta)
                        .WithMany(o => o.Incricoes)
                        .HasForeignKey(i => i.IdOferta);

            modelBuilder.Entity<Inscricao>()
                        .HasOne<Candidato>(i => i.Candidato)
                        .WithMany(o => o.Incricoes)
                        .HasForeignKey(i => i.IdCadidatos);

            modelBuilder.Entity<Inscricao>()
                        .HasOne<ProcessoSeletivo>(i => i.ProcessoSeletivo)
                        .WithMany(o => o.Incricoes)
                        .HasForeignKey(i => i.IdProcessoSeletivo);

            modelBuilder.Entity<Candidato>()
                        .HasIndex(p => p.CPF)
                        .IsUnique();

            modelBuilder.Entity<Inscricao>()
                        .HasIndex(i => i.NumInscricao)
                        .IsUnique();
        }
    }
}
