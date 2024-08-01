using Microsoft.EntityFrameworkCore;
using SistemaCRM.DAO.Map;
using SistemaCRM.Models;

namespace SistemaCRM.DAO
{
    public class CRMDBContex : DbContext
    {
        public CRMDBContex(DbContextOptions<CRMDBContex> options) : base(options)
        {

        }

        public DbSet<ProcessoModel> Processos { get; set; }
        public DbSet<CandidatoModel> Candidatos { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<InscricaoModel> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CandidatoMap());
            modelBuilder.ApplyConfiguration(new InscricaoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new ProcessoMap());
            base.OnModelCreating(modelBuilder);
            
        }

    }

}
