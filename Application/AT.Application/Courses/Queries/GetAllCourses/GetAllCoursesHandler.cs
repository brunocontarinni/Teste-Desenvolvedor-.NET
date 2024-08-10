using AT.Application.Courses.Queries.GetAllCourses.Request;
using AT.Application.Courses.Queries.GetAllCourses.Responses;
using AT.Domain.Repositories.Courses;
using MediatR;

namespace AT.Application.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesHandler(ICoursesRepository coursesRepository) : IRequestHandler<GetAllCoursesRequest, IEnumerable<GetAllCoursesResponse>>
    {
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task<IEnumerable<GetAllCoursesResponse>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
        {
            var courses = await _coursesRepository.GetAllAsync();
            var responses = courses.Where(c => string.IsNullOrWhiteSpace(request.Term) ||
                                          c.Name.Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase)).Select(res => new GetAllCoursesResponse
                                          {
                                              Id = res.Id,
                                              Name = res.Name,
                                              Description = res.Description,
                                              AvailableVacancies = res.AvailableVacancies
                                          }).ToList();
            return responses;
        }
    }
}