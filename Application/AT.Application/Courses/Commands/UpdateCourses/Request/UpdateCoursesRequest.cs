using MediatR;

namespace AT.Application.Courses.Commands.UpdateCourses.Request
{
    public class UpdateCoursesRequest : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; }
    }
}