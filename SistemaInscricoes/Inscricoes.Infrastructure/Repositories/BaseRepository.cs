using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Inscricoes.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	protected readonly AppDbContext _context;

	public BaseRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<TEntity?> GetByIdAsync(int id)
	{
		return await _context.Set<TEntity>().FindAsync(id);
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(TEntity entity)
	{
		ValidateEntity(entity);
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(TEntity entity)
	{
		ValidateEntity(entity);
		_context.Entry(entity).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(TEntity entity)
	{
		_context.Set<TEntity>().Remove(entity);
		await _context.SaveChangesAsync();
	}

	public virtual void ValidateEntity(TEntity entity)
	{
		HandlerClassUtil.TrimAllStrings(entity);
	}
}
