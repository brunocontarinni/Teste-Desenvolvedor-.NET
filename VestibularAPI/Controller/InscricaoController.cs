using Microsoft.AspNetCore.Mvc;
using VestibularAPI.Data;
using VestibularAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class InscricoesController : ControllerBase
{
    private readonly VestibularContext _context;
    private readonly InscricaoRepository _repository;

    public InscricoesController(VestibularContext context, InscricaoRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    // GET: api/inscricao/cpf/{cpf}
    [HttpGet("cpf/{cpf}")]
    public ActionResult<IEnumerable<Inscricao>> GetInscricoesByCpf(string cpf)
    {
        var inscricoes = _repository.GetInscricoesByCpf(cpf);
        if (inscricoes == null || !inscricoes.Any())
        {
            return NotFound();
        }

        return Ok(inscricoes);
    }

    // GET: api/inscricao/oferta/{ofertaId}
    [HttpGet("oferta/{ofertaId}")]
    public ActionResult<IEnumerable<Inscricao>> GetInscricoesByOferta(int ofertaId)
    {
        var inscricoes = _repository.GetInscricoesByOferta(ofertaId);
        if (inscricoes == null || !inscricoes.Any())
        {
            return NotFound();
        }

        return Ok(inscricoes);
    }
    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inscricao>>> GetAll()
    {
        return await _context.Inscricoes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inscricao>> GetById(int id)
    {
        var processo = await _context.Inscricoes.FindAsync(id);

        if (processo == null)
        {
            return NotFound();
        }

        return processo;
    }

    [HttpPost]
    public async Task<ActionResult<Inscricao>> Create(Inscricao inscricao)
    {
        _context.Inscricoes.Add(inscricao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = inscricao.ID }, inscricao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Inscricao inscricao)
    {
        if (id != inscricao.ID)
        {
            return BadRequest();
        }

        _context.Entry(inscricao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Inscricoes.Any(e => e.ID == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var inscricao = await _context.Inscricoes.FindAsync(id);

        if (inscricao == null)
        {
            return NotFound();
        }

        _context.Inscricoes.Remove(inscricao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
