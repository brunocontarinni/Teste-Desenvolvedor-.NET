using AT.Application.Inscriptions.Commands.AddInscription.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Candidates;
using AT.Domain.Repositories.Courses;
using AT.Domain.Repositories.Inscriptions;
using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.Inscriptions.Commands.AddInscription
{
    public class AddInscriptionsHandler(IInscriptionsRepository inscriptionsRepository,
                                        ICandidatesRepository candidatesRepository,
                                        ISelectionProcessesRepository selectionProcessesRepository,
                                        ICoursesRepository coursesRepository) : IRequestHandler<AddInscriptionsRequest>
    {
        private readonly IInscriptionsRepository _inscriptionsRepository = inscriptionsRepository;
        private readonly ICandidatesRepository _candidatesRepository = candidatesRepository;
        private readonly ISelectionProcessesRepository _selectionProcessesRepository = selectionProcessesRepository;
        private readonly ICoursesRepository _coursesRepository = coursesRepository;

        public async Task Handle(AddInscriptionsRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _candidatesRepository.GetAsync(request.CandidateId);
            var selectProcess = await _selectionProcessesRepository.GetAsync(request.SelectionProcessId);
            var course = await _coursesRepository.GetAsync(request.CourseId);

            var addTo = new Inscription
            {
                NumberInscription = Guid.NewGuid().ToString(),
                CreationAt = DateTime.Now,
                Status = request.Status,
                CandidateId = request.CandidateId,
                Candidate = candidate!,
                SelectionProcessId = request.SelectionProcessId,
                SelectionProcess = selectProcess!,
                CourseId = request.CourseId,
                Course = course!
            };

            await _inscriptionsRepository.CreateAsync(addTo);
        }
    }
}