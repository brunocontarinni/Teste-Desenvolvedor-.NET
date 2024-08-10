using AT.Domain.Entities;

namespace AT.Domain.Repositories.SelectionProcesses
{
    public interface ISelectionProcessesRepository
    {
        Task CreateAsync(SelectionProcess entity);
        Task<SelectionProcess?> GetAsync(long id);
        Task<IEnumerable<SelectionProcess>> GetAllAsync();
        Task UpdateAsync(SelectionProcess entity);
        Task DeleteAsync(long id);
    }
}