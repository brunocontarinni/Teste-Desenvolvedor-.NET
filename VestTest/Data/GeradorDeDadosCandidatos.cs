using Bogus;
using VestTest;
using Microsoft.Extensions.DependencyInjection;

public class GeradorDeDadosCandidatos
{
    private readonly VestTestDbContext _context;

    public GeradorDeDadosCandidatos(VestTestDbContext context)
    {
        _context = context;
    }

    public void GerarDados()
    {
        var faker = new Faker<Candidato>()
            .RuleFor(c => c.Nome, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.CPF, f => f.Random.Long(10000000000, 99999999999).ToString());

        // Gerar 50 candidatos fictícios
        var candidatos = faker.Generate(50);

        // Adicionar no DbContext
        _context.Candidatos.AddRange(candidatos);
        _context.SaveChanges();
    }
}
