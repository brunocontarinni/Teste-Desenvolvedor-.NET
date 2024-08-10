using AT.Application.Courses.Queries.GetCourses.Responses;
using MediatR;

namespace AT.Application.Courses.Queries.GetCourses.Request
{
    public class GetCoursesRequest : IRequest<GetCoursesResponse>
    {
        public long Id { get; set; }
    }
}