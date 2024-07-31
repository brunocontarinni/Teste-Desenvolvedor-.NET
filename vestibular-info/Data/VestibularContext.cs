using Microsoft.EntityFrameworkCore;
using vestibular_info.Models;

namespace Vestibular_info.Data
{
    public class VestibularContext : DbContext
    {
        public VestibularContext(DbContextOptions<VestibularContext> options)
            : base(options)
        {
        }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dados de exemplo
            modelBuilder.Entity<ProcessoSeletivo>().HasData(
                new ProcessoSeletivo
                {
                    Id = 1,
                    Nome = "Vestibular 2024",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now.AddMonths(1)
                }
            );

            modelBuilder.Entity<Lead>().HasData(
                new Lead { Id = 1, Nome = "João Silva", Email = "joao.silva@example.com", Telefone = "123456789", CPF = "12345678901" }
            );

            modelBuilder.Entity<Oferta>().HasData(
                new Oferta { Id = 1, Nome = "Engenharia de Software", Descricao = "Curso de Engenharia de Software", VagasDisponiveis = 50 }
            );

            modelBuilder.Entity<Inscricao>().HasData(
                new Inscricao { Id = 1, NumeroInscricao = "20240001", Data = DateTime.Now, Status = "Pendente", LeadId = 1, ProcessoSeletivoId = 1, OfertaId = 1 }
            );
        }

        public static void SeedData(VestibularContext context)
        {
            if (!context.ProcessosSeletivos.Any())
            {
                context.ProcessosSeletivos.AddRange(
                    new ProcessoSeletivo
                    {
                        Id = 1,
                        Nome = "Vestibular 2024",
                        DataInicio = DateTime.Now,
                        DataTermino = DateTime.Now.AddMonths(1)
                    }
                );
            }

            if (!context.Leads.Any())
            {
                context.Leads.AddRange(
                    new Lead
                    {
                        Id = 1,
                        Nome = "João Silva",
                        Email = "joao.silva@example.com",
                        Telefone = "123456789",
                        CPF = "12345678901"
                    }
                );
            }

            if (!context.Ofertas.Any())
            {
                context.Ofertas.AddRange(
                    new Oferta
                    {
                        Id = 1,
                        Nome = "Engenharia de Software",
                        Descricao = "Curso de Engenharia de Software",
                        VagasDisponiveis = 50
                    }
                );
            }

            if (!context.Inscricoes.Any())
            {
                context.Inscricoes.AddRange(
                    new Inscricao
                    {
                        Id = 1,
                        NumeroInscricao = "20240001",
                        Data = DateTime.Now,
                        Status = "Pendente",
                        LeadId = 1,
                        ProcessoSeletivoId = 1,
                        OfertaId = 1
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
