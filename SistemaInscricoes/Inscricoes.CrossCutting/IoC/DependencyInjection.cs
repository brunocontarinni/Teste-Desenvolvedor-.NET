using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Inscricoes.Infrastructure.Repositories;
using Inscricoes.Application.Interfaces;
using Inscricoes.Application.Services;
using Inscricoes.Application.Mapper;

namespace Inscricoes.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Repositories
        services.AddScoped<ILeadRepository, LeadRepository>();
        services.AddScoped<IProcessoSeletivoRepository, ProcessoSeletivoRepository>();
        services.AddScoped<IOfertaRepository, OfertaRepository>();
        services.AddScoped<IInscricaoRepository, InscricaoRepository>();

        // Services
        services.AddScoped<ILeadService, LeadService>();
        services.AddScoped<IProcessoSeletivoService, ProcessoSeletivoService>();
        services.AddScoped<IOfertaService, OfertaService>();
        services.AddScoped<IInscricaoService, InscricaoService>();
        services.AddScoped<ITokenService, TokenService>();

        // Mapper Service
        services.AddScoped<IMapperService, MapperService>();

        return services;
    }
}
