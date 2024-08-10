using AT.API.Controllers.ViewModels;
using AT.Application.Candidates.Commands.AddCandidate.Request;
using AT.Application.Candidates.Commands.DeleteCandidates.Request;
using AT.Application.Candidates.Commands.UpdateCandidates.Request;
using AT.Application.Candidates.Queries.GetAllCandidates.Request;
using AT.Application.Candidates.Queries.GetAllCandidates.Responses;
using AT.Application.Candidates.Queries.GetCandidates.Request;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : BaseController
    {
        /// <summary>
        /// Get all candidate
        /// </summary>
        /// <param name="term">Enter name candidate</param>
        /// <returns>If there is a candidate, return the candidate, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllCandidatesResponse>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                var request = new GetAllCandidatesRequest { Term = term };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve candidate by id
        /// </summary>
        /// <param name="id">Candidate identifier</param> 
        /// <returns>If there is a candidate, return the candidate, if not, return null</returns>
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllCandidatesResponse>))]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var request = new GetCandidatesRequest { Id = id };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Candidate creation
        /// </summary>
        /// <param name="viewModel">Object representing an candidate</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create([FromBody] AddCandidatesViewModel viewModel)
        {
            try
            {
                var request = new AddCandidatesRequest
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    PersonalNumber = viewModel.PersonalNumber
                };

                await Mediator!.Send(request);

                return Ok("Candidato criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadidate update
        /// </summary>
        /// <param name="viewModel">Object representing an candidate</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Update([FromForm] UpdateCandidatesViewModel viewModel)
        {
            try
            {
                var request = new UpdateCandidatesRequest
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    PersonalNumber = viewModel.PersonalNumber
                };

                await Mediator!.Send(request);

                return Ok("Candidato atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete candidate
        /// </summary>
        /// <param name="id">Candidate identifier</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var request = new DeleteCandidatesRequest
                {
                    Id = id
                };

                await Mediator!.Send(request);

                return Ok("Candidato excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}