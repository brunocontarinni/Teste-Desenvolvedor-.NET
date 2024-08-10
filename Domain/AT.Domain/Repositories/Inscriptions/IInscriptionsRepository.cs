using AT.Domain.Entities;

namespace AT.Domain.Repositories.Inscriptions
{
    public interface IInscriptionsRepository
    {
        Task CreateAsync(Inscription entity);
        Task<Inscription?> GetAsync(long id);
        Task<IEnumerable<Inscription>> GetAllAsync();
        Task UpdateAsync(Inscription entity);
        Task DeleteAsync(long id);
    }
}