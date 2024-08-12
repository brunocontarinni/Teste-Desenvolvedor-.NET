using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadServices _LeadServices;
        public LeadController(ILeadServices LeadServices)
        {
            _LeadServices = LeadServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var lead = await _LeadServices.GetAllLeads();
                if (lead == null || !lead.Any())
                {
                    return Ok(new { message = "Sem Leads Encontrados." });
                }

                return Ok(new { message = "Leads encontrados com sucesso.", data = lead });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao encontrar todos os Leads.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead(Lead request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _LeadServices.CreateLead(request);
                return Ok(new { message = "Lead criado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao criar o Leads.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(int id, LeadDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var leadMap = await _LeadServices.GetLeadById(id);
                if (leadMap == null)
                    return NotFound(new { message = $"Lead com Id {id} não encontrado." });
                await _LeadServices.UpdateLead(id, request);
                return Ok(new { message = $"Lead de Id {id} atualizado com sucesso." });
            }
            catch (Exception err)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao tentar atualizar o Lead de Id {id}" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            try
            {
                await _LeadServices.DeleteLead(id);
                return Ok(new { message = $"Lead com Id {id} removido com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = $"Ocorreu um erro ao tentar deletar Lead com Id {id}"});
            }
        }

    }
}
