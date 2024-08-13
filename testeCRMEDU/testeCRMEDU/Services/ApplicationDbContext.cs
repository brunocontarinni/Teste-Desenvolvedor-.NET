using Microsoft.EntityFrameworkCore;
using testeCRMEDU.Models;
using Microsoft.EntityFrameworkCore;

namespace testeCRMEDU.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
