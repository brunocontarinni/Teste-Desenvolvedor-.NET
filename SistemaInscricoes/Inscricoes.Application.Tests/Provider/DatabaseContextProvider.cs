using Microsoft.EntityFrameworkCore;
using Inscricoes.Infrastructure.Context;

namespace Inscricoes.Application.Tests.Provider;

public class DatabaseContextProvider : IDisposable
{
	public readonly AppDbContext _context;

	public DatabaseContextProvider()
	{
		var options = new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString())
			.Options;

		_context = new AppDbContext(options);
	}

	public async Task CreateData<TEntity>(TEntity entity) where TEntity : class
	{
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task RemoveData<TEntity>(TEntity entity) where TEntity : class
	{
		_context.Set<TEntity>().Remove(entity);
		await _context.SaveChangesAsync();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
