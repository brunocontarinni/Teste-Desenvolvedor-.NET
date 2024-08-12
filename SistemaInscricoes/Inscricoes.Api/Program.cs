using Inscricoes.Api.Extensions;
using Inscricoes.Api.Middleware;
using Inscricoes.Application.Mapper;
using Inscricoes.CrossCutting.IoC;
using Inscricoes.Domain.Entities;
using Inscricoes.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo 
	{ 
		Title = "SistemaInscricoes.API", 
		Version = "v1",
		Description = "API para gerenciamento de inscrições em processos seletivos.",
		Contact = new OpenApiContact
		{
			Name = "Matheus Rennan",
			Email = "matheusrennan70@gmail.com"
		}
	});
	c.EnableAnnotations();

	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Bearer JWT ",
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						  new OpenApiSecurityScheme
						  {
							  Reference = new OpenApiReference
							  {
								  Type = ReferenceType.SecurityScheme,
								  Id = "Bearer"
							  }
						  },
						 new string[] {}
					}
				});
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();

var secretKey = builder.Configuration["JWT:SecretKey"]
	?? throw new ArgumentException("Invalid secret key");

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.SaveToken = true;
	options.RequireHttpsMetadata = false;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ClockSkew = TimeSpan.Zero,
		ValidAudience = builder.Configuration["JWT:ValidAudience"],
		ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
		IssuerSigningKey = new SymmetricSecurityKey(
						   Encoding.UTF8.GetBytes(secretKey))
	};
});

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowLocalhost",
		builder => builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
						  .AllowAnyMethod()
						  .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	// app.ApplyMigrations(); // Docker database
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
