using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Domain.Entities;

namespace Teste_Desenvolvedor_.NET.Data.Repositories
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
