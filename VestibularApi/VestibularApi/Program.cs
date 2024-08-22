using Microsoft.EntityFrameworkCore;
using VestibularApi.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using VestibularApi.Application.Services.Interfaces;
using VestibularApi.Application.Services.Implementations;
using VestibularApi.Domain.Repositories.Implementations;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Application.Services.Inscricao;
using VestibularApi.Domain.Repositories;
using VestibularApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VestibularApi", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICandidatoService, CandidatoService>();
builder.Services.AddScoped<ICandidatoRepository, CandidatoRepository>();

builder.Services.AddScoped<IInscricaoService, InscricaoService>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepository>();

builder.Services.AddScoped<IOfertaService, OfertaService>();
builder.Services.AddScoped<IOfertaRepository, OfertaRepository>();

builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VestibularApi v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseAuthorization();

app.MapControllers(); 


app.Urls.Add("http://*:8080");

app.Run();
