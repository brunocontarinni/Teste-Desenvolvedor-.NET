using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using VestibularApi.Application.Services.Interfaces;

namespace VestibularApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadsController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadResponse>>> GetAll()
        {
            var leads = await _leadService.ObterTodosAsync();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadResponse>> GetById(Guid id)
        {
            var lead = await _leadService.ObterPorIdAsync(id);

            if (lead == null)
            {
                return NotFound("Lead not found.");
            }

            return Ok(lead);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeadRequest leadRequest)
        {
            if (leadRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            var lead = await _leadService.CriarAsync(leadRequest);
            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LeadRequest leadRequest)
        {
            if (leadRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _leadService.AtualizarAsync(id, leadRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Lead not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _leadService.DeletarAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Lead not found.");
            }

            return NoContent();
        }
    }
}
