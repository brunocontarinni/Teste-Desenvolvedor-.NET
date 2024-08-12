using CrmTest.AppDataContext;
using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoServices _InscricaoServices;
        public InscricaoController(IInscricaoServices InscricaoServices)
        {
            _InscricaoServices = InscricaoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetALlAsync()
        {
            try
            {
                var inscricaoMap = await _InscricaoServices.GetAllInscricoes();
                if (inscricaoMap == null || !inscricaoMap.Any())
                {
                    return Ok(new { message = "Não foram encontradas inscrições." });
                }
                return Ok(new { message = "Inscrições encontradas com sucesso.", data = inscricaoMap});
            }
            catch (Exception err)
            {
                return StatusCode( 500, new {
                        message = "Ocorreu um erro ao encontrar todos os Leads.",
                        error = err.Message
                    }
                );
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateInscricao(Inscricao request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _InscricaoServices.CreateInscricao(request);
                return Ok(new { message = "Inscrição criada com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao criar a inscrição.",
                        error = ex.Message
                    }
                );
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInscricao(int id, InscricaoDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var leadMap = await _InscricaoServices.GetInscricaoById(id);
                if (leadMap == null)
                    return NotFound(new { message = $"Lead com Id {id} não encontrado." });
                await _InscricaoServices.UpdateInscricao(id, request);
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
                await _InscricaoServices.DeleteInscricao(id);
                return Ok(new { message = $"Lead com Id {id} removido com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = $"Ocorreu um erro ao tentar deletar Lead com Id {id}"});
            }
        }

    }
}

