using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Vestibular.Repositorios
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly VestibularDB Contexto;

        public Repository(VestibularDB contexto)
        {
            Contexto = contexto;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Contexto.Set<TEntity>().AddAsync(entity);
            await Contexto.SaveChangesAsync();
        }

        public void Remove(TEntity entity)
        {
            Contexto.Set<TEntity>().Remove(entity);
            Contexto?.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Contexto.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            var result = await Contexto.Set<TEntity>().FindAsync(id);
            if(result is TEntity)
                return result;

            return null;
        }

        public void Update(TEntity entity)
        {
            Contexto.Set<TEntity>().Update(entity);
            Contexto?.SaveChanges();
        }
    }
}
