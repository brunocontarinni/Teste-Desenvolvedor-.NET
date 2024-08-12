using CrmTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CrmTest.AppDataContext
{
    public class CrmTestDbContex : DbContext
    {
        private readonly DbSettings _dbsettings;

        public CrmTestDbContex(IOptions<DbSettings> dbSettings)
        {
            _dbsettings = dbSettings.Value;
        }

        public DbSet<Lead> Lead { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbsettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>().ToTable("lead").HasKey(x => x.Id);
            modelBuilder.Entity<Oferta>().ToTable("oferta").HasKey(x => x.Id);
            modelBuilder.Entity<ProcessoSeletivo>().ToTable("process_seletivo").HasKey(x => x.Id);
        }
    }
}
