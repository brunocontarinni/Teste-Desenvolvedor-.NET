using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly IProcessoSeletivoServices _processoSeletivoServices;

        public ProcessoSeletivoController(IProcessoSeletivoServices ProcessoSeletivoServices)
        {
            _processoSeletivoServices = ProcessoSeletivoServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var processoSeletivoMap = await _processoSeletivoServices.GetAllProcessoSeletivos();
                if (processoSeletivoMap == null || !processoSeletivoMap.Any())
                {
                    return Ok(new { message = "Sem Ofertas Encontrados." });
                }

                return Ok(new { message = "Ofertas encontrados com sucesso.", data = processoSeletivoMap });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao encontrar todos os Processo Seletivo.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProcessoSeletivo(ProcessoSeletivo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _processoSeletivoServices.CreateProcessoSeletivo(request);
                return Ok(new { message = "Processo Seletivo criado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "Ocorreu um erro ao criar o Processo Seletivo.",
                        error = ex.Message
                    }
                );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcessoSeletivo(int id, ProcessoSeletivoDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var processoSeletivoMap = await _processoSeletivoServices.GetProcessoSeletivoById(id);
                if (processoSeletivoMap == null)
                    return NotFound(new { message = $"Processo Seletivo com Id {id} não encontrado." });
                await _processoSeletivoServices.UpdateProcessoSeletivo(id, request);
                return Ok(new { message = $"Processo Seletivo de Id {id} atualizado com sucesso." });
            }
            catch (Exception err)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao tentar atualizar o Processo Seletivo de Id {id}" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProcessoSeletivo(int id)
        {
            try
            {
                await _processoSeletivoServices.DeleteProcessoSeletivo(id);
                return Ok(new { message = $"Processo Seletivo com Id {id} removido com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = $"Ocorreu um erro ao tentar deletar Processo Seletivo com Id {id}"});
            }
        }
    }
}

