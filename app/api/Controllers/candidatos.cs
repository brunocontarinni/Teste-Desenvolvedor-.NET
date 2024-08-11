using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

using appMain;
using appMain.Models;
using ChooserSpace;

[ApiController]
[Route("api/[controller]")]
public class CandidatosController : ControllerBase
{
    // Endpoint: GET api/candidatos
    [HttpGet]
    public IActionResult GetCandidatosAll()
    {
        List<Dictionary<string, string>> resultado = app.GetCandidatoInfo("candidato");

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma candidato encontrado.");
        }

        return Ok(resultado);
    }

    // Endpoint: GET api/candidatos/{id}
    [HttpGet("{id}")]
    public IActionResult GetCandidatosById(int id)
    {
        List<Dictionary<string, string>> resultado = app.GetCandidatoInfo("candidato", id);

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma candidato encontrado.");
        }

        return Ok(resultado);
    }

    // Endpoint: POST api/candidatos/send
    [HttpPost("send")]
    public IActionResult Createcandidato([FromBody] CandidatoModel novacandidato)
    {
        Console.WriteLine("DSADAS");
        if (novacandidato == null)
        {
            return BadRequest("candidato inválida.");
        }

        var candidatoData = new string[]
            {
                novacandidato.nome,
                novacandidato.email,
                novacandidato.telefone,
                novacandidato.cpf
            };

        Chooser.chooseFunction(candidatoData, "candidato");
        return Ok("candidato criada com sucesso");
    }

    // Endpoint: DELETE api/candidatos/delete/{id}
    [HttpDelete("delete/{id}")]
    public IActionResult deleteCandidato( int id)
    {   
        app.DeleteItem(id, "candidato");
        return Ok("deleted");
    }

    // Endpoint: PUT api/candidatos/update/{id}
    [HttpPut("update/{id}")]
    public IActionResult UpdateCandidato(int id, [FromBody] CandidatoModel novaCandidato)
    {
        if (novaCandidato == null)
        {
            return BadRequest("Candidato inválido.");
        }

         var data = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(novaCandidato.nome))
        {
            data["nome"] = novaCandidato.nome;
        }

        if (!string.IsNullOrWhiteSpace(novaCandidato.email))
        {
            data["email"] = novaCandidato.email;
        }

        if (!string.IsNullOrWhiteSpace(novaCandidato.telefone)) 
        {
            data["telefone"] = novaCandidato.telefone;
        }

        if (!string.IsNullOrWhiteSpace(novaCandidato.cpf)) 
        {
            data["cpf"] = novaCandidato.telefone;
        }

        if (data.Count == 0)
        {
            return BadRequest("Nenhum dado válido fornecido para atualização.");
        }

        // Atualiza o item no banco de dados
        app.UpdateItem(id, data, "candidato");

        return Ok("Candidato atualizada com sucesso.");
    }
}