using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class InscricaoController : ControllerBase
{
    private readonly VestTestDbContext _context;
    private readonly InscricaoService _inscricaoService;
    public InscricaoController(InscricaoService inscricaoService, VestTestDbContext context)
    {
        _inscricaoService = inscricaoService;
        _context = context;
    }


    [HttpGet("teste/{id}")]
    public async Task<IActionResult> TesteCarregamento(int id)
    {
        var inscricao = await _inscricaoService.GetById(id);
        if (inscricao == null)
        {
            return NotFound("Inscrição não encontrada.");
        }

        return Ok(inscricao); // Retorna a inscrição com os dados relacionados
    }

    [HttpGet("cpf/{cpf}")]
    public async Task<IEnumerable<InscricaoDTO>> ObterInscricoesPorCPF(string cpf)
    {
        var inscricoes = await _context.Inscricoes
            .Where(i => i.Candidato.CPF == cpf) // Filtra pelo CPF
            .Include(i => i.Candidato) // Inclui o candidato
            .Include(i => i.ProcessoSeletivo) // Inclui o processo seletivo
            .Select(i => new InscricaoDTO
            {
                Id = i.Id,
                NumeroInscricao = i.NumeroInscricao,
                Data = i.Data,
                Status = i.Status,
                CandidatoId = i.CandidatoId,
                CandidatoNome = i.Candidato.Nome,
                CandidatoCpf = i.Candidato.CPF,
                ProcessoSeletivoId = i.ProcessoSeletivoId,
                ProcessoSeletivoNome = i.ProcessoSeletivo.Nome,
                OfertaCursoId = i.OfertaCursoId,
                OfertaCursoNome = i.OfertaCurso.Nome
            })
            .ToListAsync();

        return inscricoes;
    }

    [HttpGet("por-oferta/{ofertaId}")]
    public IActionResult GetInscricoesPorOferta(int ofertaId)
    {
        var inscricoes = _context.Inscricoes
            .Where(i => i.OfertaCursoId == ofertaId)
            .Select(i => new InscricaoDTO
            {
                Id = i.Id,
                NumeroInscricao = i.NumeroInscricao,
                Data = i.Data,
                Status = i.Status,
                CandidatoId = i.CandidatoId,
                ProcessoSeletivoId = i.ProcessoSeletivoId,
                OfertaCursoId = i.OfertaCursoId
            })
            .ToList();

        if (inscricoes.Count == 0)
            return NotFound("Nenhuma inscrição encontrada para essa oferta.");

        return Ok(inscricoes);
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var inscricoes = await _context.Inscricoes
            .Select(i => new InscricaoDTO
            {
                Id = i.Id,
                NumeroInscricao = i.NumeroInscricao,
                Data = i.Data,
                Status = i.Status,
                CandidatoId = i.CandidatoId,
                ProcessoSeletivoId = i.ProcessoSeletivoId,
                OfertaCursoId = i.OfertaCursoId
            })
            .ToListAsync();

        return Ok(inscricoes);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // Chama o serviço para obter a inscrição
        var inscricaoDto = await _inscricaoService.GetById(id);

        // Verifica se não encontrou a inscrição
        if (inscricaoDto == null)
        {
            return NotFound(); // Retorna 404 se não encontrar
        }

        return Ok(inscricaoDto); // Retorna 200 OK com os dados
    }



    [HttpPost]
    public IActionResult Create([FromBody] Inscricao inscricao)
    {
        if (inscricao == null)
        {
            return BadRequest("Inscrição inválida.");
        }

        _context.Inscricoes.Add(inscricao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = inscricao.Id }, inscricao);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Inscricao inscricao)
    {
        if (id != inscricao.Id)
        {
            return BadRequest("ID do recurso não corresponde.");
        }

        var existingInscricao = _context.Inscricoes.Find(id);
        if (existingInscricao == null)
        {
            return NotFound();
        }

        // Atualizar os dados da inscrição existente
        existingInscricao.NumeroInscricao = inscricao.NumeroInscricao;
        existingInscricao.Data = inscricao.Data;
        existingInscricao.Status = inscricao.Status;
        existingInscricao.OfertaCursoId = inscricao.OfertaCursoId;
        existingInscricao.CandidatoId = inscricao.CandidatoId;
        existingInscricao.ProcessoSeletivoId = inscricao.ProcessoSeletivoId;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var inscricao = _context.Inscricoes.Find(id);
        if (inscricao == null)
        {
            return NotFound();
        }

        _context.Inscricoes.Remove(inscricao);
        _context.SaveChanges();

        return NoContent();
    }

}
