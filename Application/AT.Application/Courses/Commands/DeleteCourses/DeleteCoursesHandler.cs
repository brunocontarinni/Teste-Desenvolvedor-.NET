using AT.Application.Courses.Commands.DeleteCourses.Request;
using AT.Domain.Repositories.Courses;
using MediatR;

namespace AT.Application.Courses.Commands.DeleteCourses
{
    public class DeleteCoursesHandler(ICoursesRepository coursesRepository) : IRequestHandler<DeleteCoursesRequest>
    {
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task Handle(DeleteCoursesRequest request, CancellationToken cancellationToken)
        {
            await _coursesRepository.DeleteAsync(request.Id);
        }
    }
}