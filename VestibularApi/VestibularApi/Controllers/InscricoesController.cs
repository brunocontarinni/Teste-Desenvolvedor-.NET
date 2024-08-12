using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularApi.Data;
using VestibularApi.Models;

namespace VestibularApi.Controllers
{
    /// <summary>
    /// API Controller para gerenciar inscrições no sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly VestibularContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="InscricaoController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do vestibular.</param>
        public InscricaoController(VestibularContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as inscrições.
        /// </summary>
        /// <returns>Uma lista de inscrições.</returns>
        /// <response code="200">Retorna a lista de inscrições.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoes()
        {
            // Inclui as relações para que os dados relacionados sejam carregados juntos
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Curso)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna uma inscrição específica pelo ID.
        /// </summary>
        /// <param name="id">ID da inscrição.</param>
        /// <returns>A inscrição correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna a inscrição solicitada.</response>
        /// <response code="404">Se a inscrição não for encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> GetInscricao(int id)
        {
            var inscricao = await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Curso)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inscricao == null)
            {
                return NotFound(new { Message = "Inscrição não encontrada." });
            }

            return inscricao;
        }

        /// <summary>
        /// Retorna todas as inscrições associadas a um candidato específico pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do candidato.</param>
        /// <returns>Uma lista de inscrições associadas ao CPF fornecido.</returns>
        /// <response code="200">Retorna a lista de inscrições para o CPF fornecido.</response>
        /// <response code="404">Se nenhuma inscrição for encontrada para o CPF.</response>
        [HttpGet("ByCPF/{cpf}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesByCpf(string cpf)
        {
            var inscricoes = await _context.Inscricoes
                                           .Include(i => i.Candidato)
                                           .Include(i => i.ProcessoSeletivo)
                                           .Where(i => i.Candidato.CPF == cpf)
                                           .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound(new { Message = "Nenhuma inscrição encontrada para este CPF." });
            }

            return Ok(inscricoes);
        }

        /// <summary>
        /// Cria uma nova inscrição.
        /// </summary>
        /// <param name="inscricao">Dados da inscrição a ser criada.</param>
        /// <returns>A inscrição criada.</returns>
        /// <response code="201">Retorna a inscrição recém-criada.</response>
        /// <response code="400">Se os dados da inscrição forem inválidos ou se o curso estiver cheio.</response>
        /// <response code="404">Se o curso não for encontrado.</response>
        [HttpPost]
        public async Task<ActionResult<Inscricao>> PostInscricao(Inscricao inscricao)
        {
            if (inscricao == null)
            {
                return BadRequest(new { Message = "Dados da inscrição inválidos." });
            }

            var curso = await _context.Cursos.FindAsync(inscricao.CursoId);

            if (curso == null)
            {
                return NotFound(new { Message = "Curso não encontrado." });
            }

            // Verifica se o curso já atingiu o limite de vagas
            int inscricoesNoCurso = _context.Inscricoes.Count(i => i.CursoId == inscricao.CursoId);
            if (inscricoesNoCurso >= curso.VagasDisponiveis)
            {
                return BadRequest(new { Message = "Este curso já atingiu o limite de vagas disponíveis." });
            }

            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInscricao), new { id = inscricao.Id }, inscricao);
        }

        /// <summary>
        /// Atualiza os dados de uma inscrição existente.
        /// </summary>
        /// <param name="id">ID da inscrição a ser atualizada.</param>
        /// <param name="inscricao">Dados atualizados da inscrição.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se o ID da inscrição não corresponder ao informado.</response>
        /// <response code="404">Se a inscrição não for encontrada.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricao(int id, Inscricao inscricao)
        {
            if (id != inscricao.Id)
            {
                return BadRequest(new { Message = "ID da inscrição não corresponde." });
            }

            _context.Entry(inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(id))
                {
                    return NotFound(new { Message = "Inscrição não encontrada." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui uma inscrição pelo ID.
        /// </summary>
        /// <param name="id">ID da inscrição a ser excluída.</param>
        /// <response code="204">Se a exclusão for bem-sucedida.</response>
        /// <response code="404">Se a inscrição não for encontrada.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricao(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound(new { Message = "Inscrição não encontrada." });
            }

            _context.Inscricoes.Remove(inscricao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica se uma inscrição com o ID fornecido existe.
        /// </summary>
        /// <param name="id">ID da inscrição.</param>
        /// <returns>Verdadeiro se a inscrição existir; caso contrário, falso.</returns>
        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }
    }
}
