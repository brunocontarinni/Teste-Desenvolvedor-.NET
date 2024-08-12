using Inscricoes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Inscricoes.Api.Extensions;

public static class MigrationExtensions
{
	public static void ApplyMigrations(this IApplicationBuilder app)
	{
		using (IServiceScope scope = app.ApplicationServices.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			var retries = 10;
			while (retries > 0)
			{
				try
				{
					dbContext.Database.Migrate();
					break;
				}
				catch (SocketException)
				{
					retries--;
					Thread.Sleep(2000);
				}
			}
		}
	}
}
