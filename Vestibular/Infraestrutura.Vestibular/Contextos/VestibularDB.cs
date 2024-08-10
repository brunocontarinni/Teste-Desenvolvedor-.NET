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
                        .HasOne<Oferta>(ins => ins.Oferta)
                        .WithMany(of => of.Incricoes)
                        .HasForeignKey(ins => ins.IdOferta);

            modelBuilder.Entity<Inscricao>()
                        .HasOne<Candidato>(ins => ins.Candidato)
                        .WithMany(of => of.Incricoes)
                        .HasForeignKey(ins => ins.IdOferta);

            modelBuilder.Entity<Inscricao>()
                        .HasOne<ProcessoSeletivo>(ins => ins.ProcessoSeletivo)
                        .WithMany(of => of.Incricoes)
                        .HasForeignKey(ins => ins.IdOferta);
        }
    }
}
