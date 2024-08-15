using Microsoft.EntityFrameworkCore;
using VestibularAPI.Models;

namespace VestibularAPI.Data
{
    public class VestibularContext : DbContext
    {
        public VestibularContext(DbContextOptions<VestibularContext> options) : base(options) { }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}