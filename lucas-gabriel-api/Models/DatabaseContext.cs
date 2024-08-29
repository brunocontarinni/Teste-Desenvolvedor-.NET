using Microsoft.EntityFrameworkCore;
using lucas_gabriel_api.Models.Entitys;

namespace lucas_gabriel_api.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {

    }


    public DbSet<ProcessoSeletivo> ProcessoSeletivos { get; set; } = default!;
    public DbSet<Lead> Leads { get; set; } = default!;
    public DbSet<Oferta> Ofertas { get; set; } = default!;

    public DbSet<Inscricao> Inscricoes { get; set; } = default!;


}

