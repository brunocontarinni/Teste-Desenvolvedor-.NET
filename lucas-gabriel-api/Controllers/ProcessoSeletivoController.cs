using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources;
using lucas_gabriel_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucas_gabriel_api.Controllers;

[ApiController]
[Route("/processo/seletivo")]
public class ProcessoSeletivoController : ControllerBase
{

    private ProcessoSeletivoServices _services;

    public ProcessoSeletivoController(DatabaseContext context)
    {
        this._services = new ProcessoSeletivoServices(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> ListAllProcessoSeletivo()
    {

        List<ProcessoSeletivo> processosSeletivos = await this._services.ListProcessoService();

        if (processosSeletivos == null || !processosSeletivos.Any())
            return NotFound(new Response<ProcessoSeletivo> { Code = 404, Message = "processos-seletivoss-not-found" });

        return Ok(new Response<ProcessoSeletivo>
        {
            Code = 200,
            Message = "processos-seletivos-founded",
            Data = processosSeletivos
        });
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProcessoSeletivo>> GetProcessoSeletivo(int id)
    {

        ProcessoSeletivo? processoSeletivo = await this._services.GetProcessoSeletivoByIdService(id);

        if (processoSeletivo == null)
        {

            return NotFound(new Response<ProcessoSeletivo>
            {
                Code = 404,
                Message = "processo-seletivo-not-found",
            });
        }

        return Ok(new Response<ProcessoSeletivo>
        {
            Code = 200,
            Message = "processo-seletivo-found",
            Data = new List<ProcessoSeletivo>() { processoSeletivo }
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateProcessoSeletivo(ProcessoSeletivo processoSeletivo)
    {
        if (processoSeletivo == null)
        {
            return StatusCode(422, new Response<ProcessoSeletivo>
            {
                Code = 422,
                Message = "processos-seletivos-cannnot-be-empty"
            });
        }

        if (processoSeletivo.Id != 0)
        {
            return StatusCode(422, new Response<ProcessoSeletivo>
            {
                Code = 422,
                Message = "processo-seletivo-inconsistency"
            });

        }

        ProcessoSeletivo processoSeletivoCreated = await _services.CreateProcessoSeletivoService(processoSeletivo);

        return Ok(new Response<ProcessoSeletivo>
        {
            Code = 200,
            Message = "processo-seletivo-created",
            Data = new List<ProcessoSeletivo> { processoSeletivoCreated }
        });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProcessoSeletivo(int id, ProcessoSeletivo processoSeletivo)
    {

        if (processoSeletivo == null)
        {
            return StatusCode(422, new Response<ProcessoSeletivo>
            {
                Code = 422,
                Message = "processo-seletivo-cannnot-be-empty"
            });
        }

        if (id != processoSeletivo.Id)
        {
            return StatusCode(422, new Response<ProcessoSeletivo>
            {
                Code = 422,
                Message = "processo-seletivo-id-inconsistency"
            });
        }


        ProcessoSeletivo? updatedProcessoSeletivo = await this._services.UpdateProcessoSeletivoService(processoSeletivo);

        return Ok(new Response<ProcessoSeletivo>
        {
            Code = 200,
            Message = "oferta-updated",
            Data = new List<ProcessoSeletivo> { updatedProcessoSeletivo! }
        });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProcessoSeletivo(int id)
    {

        ProcessoSeletivo? deletedProcessoSeletivo = await this._services.DeleteProcessoSeletivoService(id);

        return Ok(new Response<ProcessoSeletivo>
        {
            Code = 200,
            Message = "oferta-deleted",
            Data = new List<ProcessoSeletivo> { deletedProcessoSeletivo! }
        });
    }

}