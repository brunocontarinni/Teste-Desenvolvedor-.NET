using Bogus;
using VestTest;
using Microsoft.Extensions.DependencyInjection;

public class GeradorDeDadosOfertaCursos
{
    private readonly VestTestDbContext _context;

    public GeradorDeDadosOfertaCursos(VestTestDbContext context)
    {
        _context = context;
    }

    public void GerarDados()
    {
        var faker = new Faker<OfertaCurso>()
            .RuleFor(o => o.Nome, f => f.Company.CompanyName())
            .RuleFor(o => o.Descricao, f => f.Lorem.Paragraph())
            .RuleFor(o => o.VagasDisponiveis, f => f.Random.Int(10, 100));

        var ofertas = faker.Generate(50);

        _context.OfertaCursos.AddRange(ofertas);
        _context.SaveChanges();
    }
}
