using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources;
using lucas_gabriel_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucas_gabriel_api.Controllers;

[ApiController]
[Route("/oferta")]
public class OfertaController : ControllerBase
{

    private OfertaServices _services;

    public OfertaController(DatabaseContext context)
    {
        this._services = new OfertaServices(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Oferta>>> ListAllOferta()
    {

        List<Oferta> ofertas = await this._services.ListOfertaService();

        if (ofertas == null || !ofertas.Any())
            return NotFound(new Response<Oferta> { Code = 404, Message = "ofertas-not-found" });

        return Ok(new Response<Oferta>
        {
            Code = 200,
            Message = "ofertas-founded",
            Data = ofertas
        });
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Oferta>> GetOferta(int id)
    {

        Oferta? oferta = await this._services.GetOfertaByIdService(id);

        if (oferta == null)
        {

            return NotFound(new Response<Oferta>
            {
                Code = 404,
                Message = "oferta-not-found",
            });
        }

        return Ok(new Response<Oferta>
        {
            Code = 200,
            Message = "oferta-found",
            Data = new List<Oferta>() { oferta }
        });
    }

    [HttpPost]
    public async Task<ActionResult> CreateOferta(Oferta oferta)
    {
        if (oferta == null)
        {
            return StatusCode(422, new Response<Oferta>
            {
                Code = 422,
                Message = "oferta-cannnot-be-empty"
            });
        }

        if (oferta.Id != 0)
        {
            return StatusCode(422, new Response<Oferta>
            {
                Code = 422,
                Message = "oferta-inconsistency"
            });

        }

        Oferta ofertaCreated = await _services.CreateOfertaService(oferta);

        return Ok(new Response<Oferta>
        {
            Code = 200,
            Message = "oferta-created",
            Data = new List<Oferta> { ofertaCreated }
        });

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOferta(int id, Oferta oferta)
    {

        if (oferta == null)
        {
            return StatusCode(422, new Response<Oferta>
            {
                Code = 422,
                Message = "oferta-cannnot-be-empty"
            });
        }

        if (id != oferta.Id)
        {
            return StatusCode(422, new Response<Oferta>
            {
                Code = 422,
                Message = "oferta-id-inconsistency"
            });
        }


        Oferta? updatedOferta = await this._services.UpdateOfertaService(oferta);

        return Ok(new Response<Oferta>
        {
            Code = 200,
            Message = "oferta-updated",
            Data = new List<Oferta> { updatedOferta! }
        });

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOferta(int id)
    {

        Oferta? deletedOferta = await this._services.DeleteOfertaService(id);

        return Ok(new Response<Oferta>
        {
            Code = 200,
            Message = "oferta-deleted",
            Data = new List<Oferta> { deletedOferta! }
        });
    }

}