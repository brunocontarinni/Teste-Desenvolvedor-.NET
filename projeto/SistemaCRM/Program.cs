
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaCRM.DAO;
using SistemaCRM.Repositorio;
using SistemaCRM.Repositorio.Interfaces;
using System.Text.Json.Serialization;

namespace SistemaCRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddRazorPages();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(

                 c =>
                 {
                     c.EnableAnnotations();
                     c.SwaggerDoc("v1", new OpenApiInfo
                     {
                         Title = "Swagger Documentação Web API",
                         Description = "API de teste para a vaga de Analista Programador Pleno.",
                         Contact = new OpenApiContact() { Name = "Paulo henrique Lopes", Email = "pauloamaral2006@yahoo.com.br" },
                         License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
                     });
                     c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                 }
            );
            
            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            builder.Services.AddDbContext<CRMDBContex>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddScoped<ICandidatoRepositorio, CandidatoRepositorio>();
            builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            builder.Services.AddScoped<IInscricaoRepositorio, InscricaoRepositorio>();
            builder.Services.AddScoped<IProcessoRepositorio, ProcessoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }

}
