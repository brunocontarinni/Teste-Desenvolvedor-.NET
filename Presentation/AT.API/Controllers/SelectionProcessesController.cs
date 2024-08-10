using AT.API.Controllers.ViewModels;
using AT.Application.SelectionProcesses.Commands.AddSelectionProcesses.Request;
using AT.Application.SelectionProcesses.Commands.DeleteSelectionProcesses;
using AT.Application.SelectionProcesses.Commands.UpdateSelectionProcesses.Request;
using AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Request;
using AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Responses;
using AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Request;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionProcessesController : BaseController
    {
        /// <summary>
        /// Get all selection process
        /// </summary>
        /// <param name="term">Enter name selection process</param>
        /// <returns>If there is a selection process, return the selection process, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllSelectionProcessesResponse>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                var request = new GetAllSelectionProcessesRequest { Term = term };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve selection process by id
        /// </summary>
        /// <param name="id">Selection process identifier</param> 
        /// <returns>If there is a selection process, return the selection process, if not, return null</returns>
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllSelectionProcessesResponse>))]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var request = new GetSelectionProcessesRequest { Id = id };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Selection process creation
        /// </summary>
        /// <param name="viewModel">Object representing an selection process</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create([FromBody] AddSelectionProcessesViewModel viewModel)
        {
            try
            {
                var request = new AddSelectionProcessesRequest
                {
                    Name = viewModel.Name,
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate
                };

                await Mediator!.Send(request);

                return Ok("Processo seletivo criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Selection process update
        /// </summary>
        /// <param name="viewModel">Object representing an selection process</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Update([FromForm] UpdateSelectionProcessesViewModel viewModel)
        {
            try
            {
                var request = new UpdateSelectionProcessesRequest
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate
                };

                await Mediator!.Send(request);

                return Ok("Processo seletivo atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete selection process
        /// </summary>
        /// <param name="id">Selection process identifier</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var request = new DeleteSelectionProcessesRequest
                {
                    ID = id
                };

                await Mediator!.Send(request);

                return Ok("Processo seletivo excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}