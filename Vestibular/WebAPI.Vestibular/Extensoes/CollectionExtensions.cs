using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Infraestrutura.Vestibular.Negocios;
using Infraestrutura.Vestibular.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Vestibular.Extensoes
{
    public static class CollectionExtensions
    {
        public static void RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<IOfertaRepository, OfertaRepository>();
            services.AddScoped<IInscricaoRepository, InscricaoRepository>();
            services.AddScoped<IProcessoSeletivoRepository, ProcessoSeletivoRepository>();
            services.AddScoped<CandidatoBll>();
            services.AddScoped<OfertaBll>();
            services.AddScoped<InscricaoBll>();
            services.AddScoped<ProcessoSeletivoBll>();
        }

        public static void Migrations(this IServiceProvider services)
        {
            services.CreateScope().ServiceProvider.GetRequiredService<VestibularDB>()
            .Database.Migrate();
        }
    }
}
