using AT.Application.Courses.Queries.GetCourses.Request;
using AT.Application.Courses.Queries.GetCourses.Responses;
using AT.Domain.Repositories.Courses;
using MediatR;

namespace AT.Application.Courses.Queries.GetCourses
{
    public class GetCoursesHandler(ICoursesRepository coursesRepository) : IRequestHandler<GetCoursesRequest, GetCoursesResponse>
    {
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task<GetCoursesResponse> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
        {
            var course = await _coursesRepository.GetAsync(request.Id);
            var responses = new GetCoursesResponse
            {
                Id = course!.Id,
                Name = course.Name,
                Description = course.Description,
                AvailableVacancies = course.AvailableVacancies
            };

            return responses;
        }
    }
}