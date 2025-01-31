using Bogus;
using VestTest;
using Microsoft.Extensions.DependencyInjection;
using System;

public class GeradorDeDadosProcessoSeletivo
{
    private readonly VestTestDbContext _context;

    public GeradorDeDadosProcessoSeletivo(VestTestDbContext context)
    {
        _context = context;
    }

    public void GerarDados()
    {
        var faker = new Faker<ProcessoSeletivo>()
            .RuleFor(p => p.Nome, f => f.Company.CatchPhrase())
            .RuleFor(p => p.DataInicio, f => f.Date.Past(1))
            .RuleFor(p => p.DataTermino, (f, p) => f.Date.Between(p.DataInicio, p.DataInicio.AddMonths(2)));

        var processos = faker.Generate(30);

        _context.ProcessosSeletivos.AddRange(processos);
        _context.SaveChanges();
    }
}
