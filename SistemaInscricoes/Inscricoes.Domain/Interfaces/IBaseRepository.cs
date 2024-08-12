namespace Inscricoes.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
	Task<TEntity?> GetByIdAsync(int id);
	Task<IEnumerable<TEntity>> GetAllAsync();
	Task AddAsync(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task DeleteAsync(TEntity entity);
	void ValidateEntity(TEntity entity);
}