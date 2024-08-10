using AT.Domain.Entities;
using AT.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AT.Domain.Repositories.Courses
{
    public class CoursesRepository(AppDbContext context) : ICoursesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(Course entity)
        {
            _context.Courses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var courses = await GetAsync(id);

            if (courses != null)
            {
                _context.Courses.Remove(courses);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course?> GetAsync(long id)
        {
            var courses = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task UpdateAsync(Course entity)
        {
            _context.Courses.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}