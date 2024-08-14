using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Teste_Desenvolvedor_.NET.Domain.Profiles;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Services.Interfaces;
using Teste_Desenvolvedor_.NET.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste T�cnico", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var connectionStringSQL = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<DBContext>(opts =>
{
    opts.UseMySql(connectionStringSQL, ServerVersion.AutoDetect(connectionStringSQL));
});

builder.Services.AddAutoMapper(typeof(TesteProfiles));
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IOfertaService, OfertaServices>();
builder.Services.AddScoped<IProcessoSeletivoService, ProcessoSeletivoService>();
builder.Services.AddScoped<IInscricaoService, InscricaoService>();
builder.Services.AddScoped<IUtilsService, UtilsService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
