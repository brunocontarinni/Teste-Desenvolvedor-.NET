using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaServices _OfertaServices;
        public OfertaController(IOfertaServices OfertaServices)
        {
            _OfertaServices = OfertaServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var Oferta = await _OfertaServices.GetAllOfertas();
                if (Oferta == null || !Oferta.Any())
                {
                    return Ok(new { message = "Sem Ofertas Encontrados." });
                }

                return Ok(new { message = "Ofertas encontrados com sucesso.", data = Oferta });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao encontrar todos os Ofertas.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOferta(Oferta request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _OfertaServices.CreateOferta(request);
                return Ok(new { message = "Oferta criado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao criar o Ofertas.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOferta(int id, OfertaDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var OfertaMap = await _OfertaServices.GetOfertaById(id);
                if (OfertaMap == null)
                    return NotFound(new { message = $"Oferta com Id {id} não encontrado." });
                await _OfertaServices.UpdateOferta(id, request);
                return Ok(new { message = $"Oferta de Id {id} atualizado com sucesso." });
            }
            catch (Exception err)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao tentar atualizar o Oferta de Id {id}" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            try
            {
                await _OfertaServices.DeleteOferta(id);
                return Ok(new { message = $"Oferta com Id {id} removido com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = $"Ocorreu um erro ao tentar deletar Oferta com Id {id}"});
            }
        }

    }
}