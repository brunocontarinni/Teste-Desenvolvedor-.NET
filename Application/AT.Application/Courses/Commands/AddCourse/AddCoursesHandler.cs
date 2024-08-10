using AT.Application.Courses.Commands.AddCourse.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Courses;
using MediatR;

namespace AT.Application.Courses.Commands.AddCourse
{
    public class AddCoursesHandler(ICoursesRepository coursesRepository) : IRequestHandler<AddCoursesRequest>
    {
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task Handle(AddCoursesRequest request, CancellationToken cancellationToken)
        {
            var addTo = new Course
            {
                Name = request.Name,
                Description = request.Description,
                AvailableVacancies = request.AvailableVacancies
            };

            await _coursesRepository.CreateAsync(addTo);
        }
    }
}