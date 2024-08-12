using Microsoft.EntityFrameworkCore;
using Inscricoes.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{ }

	public DbSet<Inscricao> Inscricoes { get; set; }
	public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
	public DbSet<Lead> Leads { get; set; }
	public DbSet<Oferta> Ofertas { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Inscricao>()
			.HasOne(i => i.Lead)
			.WithMany(l => l.Inscricoes)
			.HasForeignKey(i => i.LeadId);

		modelBuilder.Entity<Inscricao>()
			.HasOne(i => i.ProcessoSeletivo)
			.WithMany(p => p.Inscricoes)
			.HasForeignKey(i => i.ProcessoSeletivoId);

		modelBuilder.Entity<Inscricao>()
			.HasOne(i => i.Oferta)
			.WithMany(o => o.Inscricoes)
			.HasForeignKey(i => i.OfertaId);

		modelBuilder.Entity<Lead>()
			.HasIndex(l => l.CPF)
			.IsUnique();

		modelBuilder.Entity<Inscricao>()
			.HasIndex(i => i.NumeroInscricao)
			.IsUnique();
	}
}
