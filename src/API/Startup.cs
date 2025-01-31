
using API.Middleware;
using Application.Services;
using Infrastructure;
using Infrastructure.HealthChecks;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
    
            services.AddScoped<CandidatoRepository>();
            services.AddScoped<OfertaRepository>();
            services.AddScoped<InscricaoRepository>();
            services.AddScoped<ProcessoSeletivoRepository>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<CandidatoService>();
            services.AddScoped<InscricaoService>();
            services.AddScoped<OfertaService>();
            services.AddScoped<ProcessoSeletivoService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vestibular API", Version = "v1" });
                c.EnableAnnotations();
            });

            services.AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>("Banco de Dados");
                
            services.AddSingleton(sp => new DatabaseHealthCheck(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            
            app.UseMiddleware<GlobalExceptionMiddleware>();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
