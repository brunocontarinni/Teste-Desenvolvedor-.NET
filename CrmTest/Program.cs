using CrmTest.AppDataContext;
using CrmTest.Interface;
using CrmTest.Models;
using CrmTest.Services;
using TodoAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<CrmTestDbContex>(); 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 

builder.Services.AddProblemDetails();  

builder.Services.AddLogging();  
builder.Services.AddScoped<ILeadServices, LeadServices>();
builder.Services.AddScoped<IOfertaServices, OfertaServices>();
builder.Services.AddScoped<IProcessoSeletivoServices, ProcessoSeletivoServices>();
builder.Services.AddScoped<IInscricaoServices, InscricaoServices>();
var app = builder.Build();
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider;
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();