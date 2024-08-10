using AT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AT.Domain.EntityFramework
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<SelectionProcess> SelectionProcesses { get; set; }
    }
}