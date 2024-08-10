using AT.Domain.Entities;

namespace AT.Domain.Repositories.Courses
{
    public interface ICoursesRepository
    {
        Task CreateAsync(Course entity);
        Task<Course?> GetAsync(long id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task UpdateAsync(Course entity);
        Task DeleteAsync(long id);
    }
}