using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using appMain;
using appMain.Models;
using ChooserSpace;

[ApiController]
[Route("api/[controller]")]
public class InscricoesController : ControllerBase
{
    // Endpoint: GET api/inscricoes/por-cpf/{cpf}
    [HttpGet("por-cpf/{cpf}")]
    public IActionResult GetInscricoesPorCpf(string cpf)
    {
        List<Dictionary<string, string>> resultado = app.InscriçõesPorCpf(cpf);

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma inscrição encontrada.");
        }

        return Ok(resultado);
    }
    // Endpoint: GET api/inscricoes/por-oferta/{id}
    [HttpGet("por-oferta/{id}")]
    public IActionResult GetInscricoesPorOferta(int id)
    {
        List<Dictionary<string, string>> resultado = app.InscriçõesPorOferta(id);

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma inscrição encontrada.");
        }

        return Ok(resultado);
    }

    // Endpoint: GET api/inscricoes
    [HttpGet()]
    public IActionResult GetInscricoesGerais()
    {
        List<Dictionary<string, string>> resultado = app.InscriçõesGerais();

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma inscrição encontrada.");
        }

        return Ok(resultado);
    }



    // Endpoint: POST api/inscricoes/send
    [HttpPost("send")]
    public IActionResult CreateInscricao([FromBody] InscricaoModel novaInscricao)
    {
        if (novaInscricao == null)
        {
            return BadRequest("Inscricao inválida.");
        }

        var InscricaoData = new string[]
            {
                novaInscricao.id_lead.ToString(),
                novaInscricao.id_oferta.ToString(),
                novaInscricao.id_processo_seletivo.ToString()
            };

        Chooser.chooseFunction(InscricaoData, "inscricao");
        return Ok("Inscricao criada com sucesso");

    }

    // Endpoint: DELETE api/ofertas/delete/{id}
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteInscricao( int id)
    {   
        app.DeleteItem(id, "inscricao");
        return Ok("deleted");
    }

    // Endpoint: PUT api/inscricoes/update/{id}
    [HttpPut("update/{id}")]
    public IActionResult UpdateInscricao(int id, [FromBody] InscricaoModel Inscricao)
    {
        if (Inscricao == null)
        {
            return BadRequest("Inscricao inválido.");
        }

        var data = new Dictionary<string, string>();

        data["status"] = Inscricao.status;

        app.UpdateItem(id, data, "inscricao");

        return Ok("Inscricao atualizada com sucesso.");
    }
}
