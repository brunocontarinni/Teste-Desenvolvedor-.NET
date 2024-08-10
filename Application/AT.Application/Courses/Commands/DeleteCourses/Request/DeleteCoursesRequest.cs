using MediatR;

namespace AT.Application.Courses.Commands.DeleteCourses.Request
{
    public class DeleteCoursesRequest : IRequest
    {
        public long Id { get; set; }
    }
}