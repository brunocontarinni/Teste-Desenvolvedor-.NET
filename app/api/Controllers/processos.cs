using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

using appMain;
using appMain.Models;
using ChooserSpace;

[ApiController]
[Route("api/[controller]")]
public class ProcessosController : ControllerBase
{
    // Endpoint: GET api/processos
    [HttpGet]
    public IActionResult GetProcessosAll()
    {
        List<Dictionary<string, string>> resultado = app.GetProcessoInfo("processo_seletivo");

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma Processo encontrado.");
        }

        return Ok(resultado);
    }

    // Endpoint: GET api/processos/{id}
    [HttpGet("{id}")]
    public IActionResult GetProcessosById(int id)
    {
        List<Dictionary<string, string>> resultado = app.GetProcessoInfo("processo_seletivo", id);

        if (resultado == null || resultado.Count == 0)
        {
            return NotFound("Nenhuma Processo encontrado.");
        }

        return Ok(resultado);
    }
    
// Endpoint: POST api/processos/send
    [HttpPost("send")]
    public IActionResult CreateProcesso([FromBody] ProcessoModel novaProcesso)
    {
        if (novaProcesso == null)
        {
            return BadRequest("Processo inválida.");
        }

        var ProcessoData = new string[]
            {
                novaProcesso.nome,
                novaProcesso.data_inicio,
                novaProcesso.data_fim
            };

        Chooser.chooseFunction(ProcessoData, "processo_seletivo");
        return Ok("processo criada com sucesso");
    }

    // Endpoint: DELETE api/processos/delete/{id}
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteProcesso( int id)
    {   
        app.DeleteItem(id, "processo_seletivo");
        return Ok("deleted");
    }

    // Endpoint: PUT api/processos/update/{id}
    [HttpPut("update/{id}")]
    public IActionResult UpdateProcesso(int id, [FromBody] ProcessoModel Processo)
    {
        if (Processo == null)
        {
            return BadRequest("Candidato inválido.");
        }

         var data = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(Processo.nome))
        {
            data["nome"] = Processo.nome;
        }

        if (!string.IsNullOrWhiteSpace(Processo.data_inicio))
        {
            data["data_inicio"] = Processo.data_inicio;
        }

        if (!string.IsNullOrWhiteSpace(Processo.data_fim)) 
        {
            data["data_fim"] = Processo.data_fim;
        }

        if (data.Count == 0)
        {
            return BadRequest("Nenhum dado válido fornecido para atualização.");
        }

        // Atualiza o item no banco de dados
        app.UpdateItem(id, data, "processo_seletivo");

        return Ok("Candidato atualizada com sucesso.");
    }
}