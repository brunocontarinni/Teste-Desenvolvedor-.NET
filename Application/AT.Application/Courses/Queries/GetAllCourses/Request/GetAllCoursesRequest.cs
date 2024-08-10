using AT.Application.Courses.Queries.GetAllCourses.Responses;
using MediatR;

namespace AT.Application.Courses.Queries.GetAllCourses.Request
{
    public class GetAllCoursesRequest : IRequest<IEnumerable<GetAllCoursesResponse>>
    {
        public string? Term { get; set; }
    }
}