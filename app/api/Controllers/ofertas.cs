using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

using appMain;
using ChooserSpace;
using appMain.Models;

[ApiController]
[Route("api/[controller]")]
public class OfertasController : ControllerBase
{
    // Endpoint: GET api/ofertas
    [HttpGet]
    public IActionResult GetOfertasAll()
    {
        List<Dictionary<string, string>> resultado = app.GetOfertaInfo("oferta");

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma oferta encontrada.");
        }

        return Ok(resultado);
    }

    // Endpoint: GET api/ofertas/{id}
    [HttpGet("{id}")]
    public IActionResult GetOfertasById(int id)
    {
        List<Dictionary<string, string>> resultado = app.GetOfertaInfo("oferta", id);

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma oferta encontrada.");
        }

        return Ok(resultado);
    }

    // Endpoint: POST api/ofertas/send
    [HttpPost("send")]
    public IActionResult CreateOferta([FromBody] OfertaModel novaOferta)
    {
        Console.WriteLine("DSADAS");
        if (novaOferta == null)
        {
            return BadRequest("Oferta inválida.");
        }

        var ofertaData = new string[]
            {
                novaOferta.nome,
                novaOferta.Descricao,
                novaOferta.vagas_disponiveis.ToString()
            };

        Chooser.chooseFunction(ofertaData, "oferta");
        return Ok("Oferta criada com sucesso");
    }

    // Endpoint: DELETE api/ofertas/delete/{id}
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteOferta( int id)
    {   
        app.DeleteItem(id, "oferta");
        return Ok("deleted");
    }

    // Endpoint: PUT api/ofertas/update/{id}
    [HttpPut("update/{id}")]
    public IActionResult UpdateOferta(int id, [FromBody] OfertaModel novaOferta)
    {
        if (novaOferta == null)
        {
            return BadRequest("Oferta inválida.");
        }

         var data = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(novaOferta.nome))
        {
            data["nome"] = novaOferta.nome;
        }

        if (!string.IsNullOrWhiteSpace(novaOferta.Descricao))
        {
            data["descricao"] = novaOferta.Descricao;
        }

        if (novaOferta.vagas_disponiveis >= 0) // Ajuste a validação conforme necessário
        {
            data["vagas_disponiveis"] = novaOferta.vagas_disponiveis.ToString();
        }

        if (data.Count == 0)
        {
            return BadRequest("Nenhum dado válido fornecido para atualização.");
        }

        // Atualiza o item no banco de dados
        app.UpdateItem(id, data, "oferta");

        return Ok("Oferta atualizada com sucesso.");
    }
}