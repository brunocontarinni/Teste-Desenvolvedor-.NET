using Bogus;
using VestTest;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class GeradorDeDadosInscricoes
{
    private readonly VestTestDbContext _context;

    public GeradorDeDadosInscricoes(VestTestDbContext context)
    {
        _context = context;
    }

    public void GerarDados()
    {
        var faker = new Faker<Inscricao>()
            .RuleFor(i => i.NumeroInscricao, f => f.Random.Int(1, 10000))
            .RuleFor(i => i.Data, f => f.Date.Past(1))
            .RuleFor(i => i.Status, f => f.Random.Bool())
            // Associando as foreign keys
            .RuleFor(i => i.OfertaCursoId, f => f.PickRandom(_context.OfertaCursos.Select(o => o.Id).ToList()))
            .RuleFor(i => i.CandidatoId, f => f.PickRandom(_context.Candidatos.Select(c => c.Id).ToList()))
            .RuleFor(i => i.ProcessoSeletivoId, f => f.PickRandom(_context.ProcessosSeletivos.Select(p => p.Id).ToList()));

        var inscricoes = faker.Generate(50);

        _context.Inscricoes.AddRange(inscricoes);
        _context.SaveChanges();
    }
}
