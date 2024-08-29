using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources;
using lucas_gabriel_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucas_gabriel_api.Controllers;

[ApiController]
[Route("/lead")]
public class LeadController : ControllerBase
{

    private LeadServices _services;

    public LeadController(DatabaseContext context)
    {
        this._services = new LeadServices(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lead>>> ListAllLeads()
    {

        List<Lead> leads = await this._services.ListLeadService();

        if (leads == null || !leads.Any())
            return NotFound(new Response<Lead> { Code = 404, Message = "leads-not-found" });

        return Ok(new Response<Lead>
        {
            Code = 200,
            Message = "leads-founded",
            Data = leads
        });
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Lead>> GetLead(int id)
    {

        Lead? lead = await this._services.GetLeadByIdService(id);

        if (lead == null)
        {

            return NotFound(new Response<Lead>
            {
                Code = 404,
                Message = "lead-not-found",
            });
        }

        return Ok(new Response<Lead>
        {
            Code = 200,
            Message = "lead-found",
            Data = new List<Lead>() { lead }
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateLead(Lead lead)
    {
        if (lead == null)
        {
            return StatusCode(422, new Response<Lead>
            {
                Code = 422,
                Message = "lead-cannnot-be-empty"
            });
        }

        if (lead.Id != 0)
        {
            return StatusCode(422, new Response<Lead>
            {
                Code = 422,
                Message = "lead-inconsistency"
            });

        }

        Lead leadCreated = await _services.CreateLeadService(lead);

        return Ok(new Response<Lead>
        {
            Code = 200,
            Message = "lead-created",
            Data = new List<Lead> { leadCreated }
        });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLead(int id, Lead lead)
    {

        if (lead == null)
        {
            return StatusCode(422, new Response<Lead>
            {
                Code = 422,
                Message = "lead-cannnot-be-empty"
            });
        }

        if (id != lead.Id)
        {
            return StatusCode(422, new Response<Lead>
            {
                Code = 422,
                Message = "lead-id-inconsistency"
            });
        }


        Lead? updatedLead = await this._services.UpdateLeadService(lead);

        return Ok(new Response<Lead>
        {
            Code = 200,
            Message = "lead-updated",
            Data = new List<Lead> { updatedLead! }
        });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLead(int id)
    {

        Lead? deletedLead = await this._services.DeleteLeadService(id);

        return Ok(new Response<Lead>
        {
            Code = 200,
            Message = "lead-deleted",
            Data = new List<Lead> { deletedLead! }
        });
    }

}