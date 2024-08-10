using AT.Application.Courses.Commands.UpdateCourses.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Courses;
using MediatR;

namespace AT.Application.Courses.Commands.UpdateCourses
{
    public class UpdateCousesHandler(ICoursesRepository coursesRepository) : IRequestHandler<UpdateCoursesRequest>
    {
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task Handle(UpdateCoursesRequest request, CancellationToken cancellationToken)
        {
            var updateTo = new Course
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                AvailableVacancies = request.AvailableVacancies
            };

            await _coursesRepository.UpdateAsync(updateTo);
        }
    }
}