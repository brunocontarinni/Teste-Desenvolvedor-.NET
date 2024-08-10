using AT.Domain.Entities;

namespace AT.Domain.Repositories.Candidates
{
    public interface ICandidatesRepository
    {
        Task CreateAsync(Candidate entity);
        Task<Candidate?> GetAsync(long id);
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task UpdateAsync(Candidate entity);
        Task DeleteAsync(long id);
    }
}