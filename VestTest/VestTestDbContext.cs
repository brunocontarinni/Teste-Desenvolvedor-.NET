using Microsoft.EntityFrameworkCore;

public class VestTestDbContext : DbContext
{
    public VestTestDbContext(DbContextOptions<VestTestDbContext> options)
        : base(options)
    {
    }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }
    public DbSet<OfertaCurso> OfertaCursos { get; set; }
    public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
}
