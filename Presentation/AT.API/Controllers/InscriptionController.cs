using AT.API.Controllers.ViewModels;
using AT.Application.Inscriptions.Commands.AddInscription.Request;
using AT.Application.Inscriptions.Commands.DeleteInscriptions.Request;
using AT.Application.Inscriptions.Commands.UpdateInscriptions.Request;
using AT.Application.Inscriptions.Queries.GetAllInscriptions.Request;
using AT.Application.Inscriptions.Queries.GetAllInscriptions.Responses;
using AT.Application.Inscriptions.Queries.GetInscriptions.Request;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionController : BaseController
    {
        /// <summary>
        /// Get all inscriptions
        /// </summary>
        /// <param name="term">Enter registration number or personal number</param>
        /// <returns>If there is a inscription, return the inscription, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllInscriptionsResponse>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                var request = new GetAllInscriptionsRequest { Term = term };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve Inscriptions by id
        /// </summary>
        /// <param name="id">Inscription identifier</param> 
        /// <returns>If there is a inscription, return the inscription, if not, return null</returns>
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllInscriptionsResponse>))]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var request = new GetInscriptionsRequest { Id = id };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registration creation
        /// </summary>
        /// <param name="viewModel">Object representing an inscription</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create([FromBody] AddInscriptionsViewModel viewModel)
        {
            try
            {
                var request = new AddInscriptionsRequest
                {
                    Status = viewModel.Status,
                    CandidateId = viewModel.CandidateId,
                    SelectionProcessId = viewModel.SelectionProcessId,
                    CourseId = viewModel.CourseId
                };

                await Mediator!.Send(request);

                return Ok("Inscrição criada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registration update
        /// </summary>
        /// <param name="viewModel">Object representing an inscription</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Update([FromForm] UpdateInscriptionsViewModel viewModel)
        {
            try
            {
                var request = new UpdateInscriptionsRequest
                {
                    Id = viewModel.Id,
                    Status = viewModel.Status,
                    CandidateId = viewModel.CandidateId,
                    SelectionProcessId = viewModel.SelectionProcessId,
                    CourseId = viewModel.CourseId
                };

                await Mediator!.Send(request);

                return Ok("Inscrição atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete inscription
        /// </summary>
        /// <param name="id">Inscription identifier</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var request = new DeleteInscriptionsRequest
                {
                    Id = id
                };

                await Mediator!.Send(request);

                return Ok("Inscrição excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}