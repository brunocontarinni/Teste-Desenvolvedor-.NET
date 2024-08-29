using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources;
using lucas_gabriel_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucas_gabriel_api.Controllers;

[ApiController]
[Route("/inscricao")]
public class InscricaoController : ControllerBase
{
    private InscricaoServices _services;

    public InscricaoController(DatabaseContext context)
    {
        this._services = new InscricaoServices(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inscricao>>> ListAllInscricoes()
    {
        List<Inscricao> inscricoes = await this._services.ListInscricaoService();

        if (inscricoes == null || !inscricoes.Any())
            return NotFound(new Response<Inscricao>
            {
                Code = 404,
                Message = "inscricoes-not-found",
            });

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricoes-found",
            Data = inscricoes!
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inscricao>> GetInscricao(int id)
    {
        Inscricao? inscricao = await this._services.GetInscricaoByIdService(id);

        if (inscricao == null)
        {

            return NotFound(new Response<Inscricao>
            {
                Code = 404,
                Message = "inscricao-not-found",
            });
        }

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricao-found",
            Data = new List<Inscricao>() { inscricao }
        });
    }

    [HttpGet("cpf/{cpf}")]
    public async Task<ActionResult> GetInscricaoByOferta(string cpf)
    {

        if (cpf.Length != 11)
            return BadRequest(new Response<Inscricao>
            {
                Code = 422,
                Message = "cpf-invalid"
            });

        List<Inscricao> inscricoes = await this._services.GetInscricaoByCpfService(cpf);

        if (inscricoes == null || !inscricoes.Any())
            return NotFound(new Response<Inscricao>
            {
                Code = 404,
                Message = "inscricoes-by-cpf-not-found"
            });

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricoes-founded",
            Data = inscricoes
        });
    }

    [HttpGet("oferta/{id}")]
    public async Task<ActionResult> GetInscricaoByOferta(int id)
    {

        List<Inscricao> inscricoes = await this._services.GetInscricaoByOfertaService(id);

        if (inscricoes == null || !inscricoes.Any())
            return NotFound(new Response<Inscricao>
            {
                Code = 404,
                Message = "inscricoes-by-oferta-not-found"
            });

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricoes-founded",
            Data = inscricoes
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateInscricao(Inscricao insrcicao)
    {
        if (insrcicao == null)
        {
            return StatusCode(422, new Response<Inscricao>
            {
                Code = 422,
                Message = "inscricao-cannnot-be-empty"
            });
        }

        if (insrcicao.Id != 0)
        {
            return StatusCode(422, new Response<Inscricao>
            {
                Code = 422,
                Message = "inscricao-inconsistency"
            });

        }

        Inscricao inscricaoCreated = await _services.CreateInscricaoService(insrcicao);

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricao-created",
            Data = new List<Inscricao> { inscricaoCreated }
        });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInscricao(int id, Inscricao inscricao)
    {

        if (inscricao == null)
        {
            return StatusCode(422, new Response<Inscricao>
            {
                Code = 422,
                Message = "inscricao-cannnot-be-empty"
            });
        }

        if (id != inscricao.Id)
        {
            return StatusCode(422, new Response<Inscricao>
            {
                Code = 422,
                Message = "inscricao-id-inconsistency"
            });
        }


        Inscricao? updatedInscricao = await this._services.UpdateInscricaoService(inscricao);

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricao-updated",
            Data = new List<Inscricao> { updatedInscricao! }
        });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInscricao(int id)
    {

        Inscricao? deletedInscricao = await this._services.DeleteInscricaoService(id);

        return Ok(new Response<Inscricao>
        {
            Code = 200,
            Message = "inscricao-deleted",
            Data = new List<Inscricao> { deletedInscricao! }
        });
    }


}