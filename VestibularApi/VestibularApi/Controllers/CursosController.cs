using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularApi.Data;
using VestibularApi.Models;

namespace VestibularApi.Controllers
{
    /// <summary>
    /// API Controller para gerenciar cursos no sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly VestibularContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CursosController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do vestibular.</param>
        public CursosController(VestibularContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os cursos.
        /// </summary>
        /// <returns>Uma lista de cursos.</returns>
        /// <response code="200">Retorna a lista de cursos.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        /// <summary>
        /// Retorna um curso específico pelo ID.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>O curso correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna o curso solicitado.</response>
        /// <response code="404">Se o curso não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound(new { Message = "Curso não encontrado." });
            }

            return curso;
        }

        /// <summary>
        /// Retorna todas as inscrições associadas a um curso específico.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>Uma lista de inscrições associadas ao curso.</returns>
        /// <response code="200">Retorna a lista de inscrições para o curso.</response>
        /// <response code="404">Se nenhuma inscrição for encontrada para o curso.</response>
        [HttpGet("{id}/Inscricoes")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesByCurso(int id)
        {
            var inscricoes = await _context.Inscricoes
                                           .Where(i => i.CursoId == id)
                                           .Include(i => i.Candidato) // Incluir dados relacionados, se necessário
                                           .Include(i => i.ProcessoSeletivo)
                                           .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound(new { Message = "Nenhuma inscrição encontrada para este curso." });
            }

            return Ok(inscricoes);
        }

        /// <summary>
        /// Cria um novo curso.
        /// </summary>
        /// <param name="curso">Dados do curso a ser criado.</param>
        /// <returns>O curso criado.</returns>
        /// <response code="201">Retorna o curso recém-criado.</response>
        /// <response code="400">Se os dados do curso forem inválidos.</response>
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        /// <summary>
        /// Atualiza os dados de um curso existente.
        /// </summary>
        /// <param name="id">ID do curso a ser atualizado.</param>
        /// <param name="curso">Dados atualizados do curso.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se o ID do curso não corresponder ao informado ou se os dados forem inválidos.</response>
        /// <response code="404">Se o curso não for encontrado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest(new { Message = "ID do Curso não corresponde." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound(new { Message = "Curso não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um curso pelo ID.
        /// </summary>
        /// <param name="id">ID do curso a ser excluído.</param>
        /// <response code="204">Se a exclusão for bem-sucedida.</response>
        /// <response code="404">Se o curso não for encontrado.</response>
        /// <response code="400">Se o curso estiver associado a uma ou mais inscrições.</response>
        /// <response code="409">Se ocorrer um erro ao tentar excluir o curso.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound(new { Message = "Curso não encontrado." });
            }

            // Verifica se o curso está associado a alguma inscrição
            bool cursoAssociado = _context.Inscricoes.Any(i => i.CursoId == id);
            if (cursoAssociado)
            {
                return BadRequest(new { Message = "Não é possível excluir o curso, pois ele está associado a uma ou mais inscrições." });
            }

            // Tenta remover o curso após a verificação
            try
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return Conflict(new { Message = "Erro ao tentar excluir o curso. Possivelmente, ele está associado a uma inscrição." });
            }

            return NoContent();
        }

        /// <summary>
        /// Verifica se um curso com o ID fornecido existe.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>Verdadeiro se o curso existir; caso contrário, falso.</returns>
        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
