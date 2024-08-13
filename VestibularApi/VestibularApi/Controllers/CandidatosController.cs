using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularApi.Data;
using VestibularApi.Models;

namespace VestibularApi.Controllers
{
    /// <summary>
    /// API Controller para gerenciar candidatos no sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly VestibularContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CandidatosController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do vestibular.</param>
        public CandidatosController(VestibularContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os candidatos ou filtra por status de atividade.
        /// </summary>
        /// <param name="isActive">Opcional. Filtra os candidatos pelo status de atividade (ativos/inativos).</param>
        /// <returns>Uma lista de candidatos filtrados.</returns>
        /// <response code="200">Retorna a lista de candidatos.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos([FromQuery] bool? isActive)
        {
            var query = _context.Candidatos.AsQueryable();

            if (isActive.HasValue)
            {
                query = query.Where(c => c.IsActive == isActive.Value);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Retorna um candidato específico pelo ID.
        /// </summary>
        /// <param name="id">ID do candidato.</param>
        /// <returns>O candidato correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna o candidato solicitado.</response>
        /// <response code="404">Se o candidato não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound(new { Message = "Candidato não encontrado." });
            }

            return candidato;
        }

        /// <summary>
        /// Cria um novo candidato.
        /// </summary>
        /// <param name="candidato">Dados do candidato a ser criado.</param>
        /// <returns>O candidato criado.</returns>
        /// <response code="201">Retorna o candidato recém-criado.</response>
        /// <response code="400">Se os dados do candidato forem inválidos.</response>
        /// <response code="409">Se já existir um candidato com o mesmo CPF.</response>
        [HttpPost]
        public async Task<ActionResult<Candidato>> PostCandidato(Candidato candidato)
        {
            if (candidato == null)
            {
                return BadRequest(new { Message = "Dados do candidato inválidos." });
            }

            // Verifica se já existe um candidato com o mesmo CPF
            bool cpfExistente = _context.Candidatos.Any(c => c.CPF == candidato.CPF);
            if (cpfExistente)
            {
                return Conflict(new { Message = "Já existe um candidato com este CPF." });
            }

            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCandidato), new { id = candidato.Id }, candidato);
        }

        /// <summary>
        /// Atualiza os dados de um candidato existente.
        /// </summary>
        /// <param name="id">ID do candidato a ser atualizado.</param>
        /// <param name="candidato">Dados atualizados do candidato.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se o ID do candidato não corresponder ao informado.</response>
        /// <response code="404">Se o candidato não for encontrado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest(new { Message = "ID do candidato não corresponde." });
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound(new { Message = "Candidato não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Marca um candidato como inativo (soft delete).
        /// </summary>
        /// <param name="id">ID do candidato a ser marcado como inativo.</param>
        /// <response code="204">Se a operação for bem-sucedida.</response>
        /// <response code="404">Se o candidato não for encontrado.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound(new { Message = "Candidato não encontrado." });
            }

            candidato.IsActive = false; // Soft delete
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica se um candidato com o ID fornecido existe.
        /// </summary>
        /// <param name="id">ID do candidato.</param>
        /// <returns>Verdadeiro se o candidato existir; caso contrário, falso.</returns>
        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
