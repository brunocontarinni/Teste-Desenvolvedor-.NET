using AT.API.Controllers.ViewModels;
using AT.Application.Courses.Commands.AddCourse.Request;
using AT.Application.Courses.Commands.DeleteCourses.Request;
using AT.Application.Courses.Commands.UpdateCourses.Request;
using AT.Application.Courses.Queries.GetAllCourses.Request;
using AT.Application.Courses.Queries.GetAllCourses.Responses;
using AT.Application.Courses.Queries.GetCourses.Request;
using Microsoft.AspNetCore.Mvc;

namespace AT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        /// <summary>
        /// Get all courses
        /// </summary>
        /// <param name="term">Enter name course</param>
        /// <returns>If there is a course, return the course, if not, return empty list</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllCoursesResponse>))]
        public async Task<ActionResult> GetAll(string? term)
        {
            try
            {
                var request = new GetAllCoursesRequest { Term = term };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieve courses by id
        /// </summary>
        /// <param name="id">Course identifier</param> 
        /// <returns>If there is a course, return the course, if not, return null</returns>
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllCoursesResponse>))]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var request = new GetCoursesRequest { Id = id };
                var result = await Mediator!.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Course creation
        /// </summary>
        /// <param name="viewModel">Object representing an course</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Create([FromBody] AddCoursesViewModel viewModel)
        {
            try
            {
                var request = new AddCoursesRequest
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    AvailableVacancies = viewModel.AvailableVacancies
                };

                await Mediator!.Send(request);

                return Ok("Curso criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Course update
        /// </summary>
        /// <param name="viewModel">Object representing an course</param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Update([FromForm] UpdateCoursesViewModel viewModel)
        {
            try
            {
                var request = new UpdateCoursesRequest
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    AvailableVacancies = viewModel.AvailableVacancies
                };

                await Mediator!.Send(request);

                return Ok("Curso atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete course
        /// </summary>
        /// <param name="id">Course identifier</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var request = new DeleteCoursesRequest
                {
                    Id = id
                };

                await Mediator!.Send(request);

                return Ok("Curso excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}