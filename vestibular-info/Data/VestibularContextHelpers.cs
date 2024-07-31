using vestibular_info.Models;
using Vestibular_info.Data;

internal static class VestibularContextHelpers
{

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