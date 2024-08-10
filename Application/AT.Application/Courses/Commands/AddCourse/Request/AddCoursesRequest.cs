using MediatR;

namespace AT.Application.Courses.Commands.AddCourse.Request
{
    public class AddCoursesRequest : IRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; }
    }
}