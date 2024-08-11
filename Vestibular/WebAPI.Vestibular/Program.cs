using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Vestibular.Extensoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Vestibular API",
        Description = "Teste Desenvolvedor .NET"
    });
});
builder.Services.AddDbContext<VestibularDB>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("VestibularContext")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.RegistrarDependencias();
var app = builder.Build();
app.Services.Migrations();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
