using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularApi.Data;
using VestibularApi.Models;

namespace VestibularApi.Controllers
{
    /// <summary>
    /// API Controller para gerenciar processos seletivos no sistema.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessosSeletivosController : ControllerBase
    {
        private readonly VestibularContext _context;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProcessosSeletivosController"/>.
        /// </summary>
        /// <param name="context">Contexto do banco de dados do vestibular.</param>
        public ProcessosSeletivosController(VestibularContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os processos seletivos.
        /// </summary>
        /// <returns>Uma lista de processos seletivos.</returns>
        /// <response code="200">Retorna a lista de processos seletivos.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> GetProcessosSeletivos()
        {
            return await _context.ProcessosSeletivos.ToListAsync();
        }

        /// <summary>
        /// Retorna um processo seletivo específico pelo ID.
        /// </summary>
        /// <param name="id">ID do processo seletivo.</param>
        /// <returns>O processo seletivo correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna o processo seletivo solicitado.</response>
        /// <response code="404">Se o processo seletivo não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoSeletivo>> GetProcessoSeletivo(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);

            if (processoSeletivo == null)
            {
                return NotFound(new { Message = "Processo Seletivo não encontrado." });
            }

            return processoSeletivo;
        }

        /// <summary>
        /// Cria um novo processo seletivo.
        /// </summary>
        /// <param name="processoSeletivo">Dados do processo seletivo a ser criado.</param>
        /// <returns>O processo seletivo criado.</returns>
        /// <response code="201">Retorna o processo seletivo recém-criado.</response>
        /// <response code="400">Se os dados do processo seletivo forem inválidos ou se as datas forem inconsistentes.</response>
        [HttpPost]
        public async Task<ActionResult<ProcessoSeletivo>> PostProcessoSeletivo(ProcessoSeletivo processoSeletivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verifica se a DataTermino é posterior à DataInicio
            if (processoSeletivo.DataTermino <= processoSeletivo.DataInicio)
            {
                return BadRequest(new { Message = "A data de término deve ser posterior à data de início." });
            }

            _context.ProcessosSeletivos.Add(processoSeletivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcessoSeletivo), new { id = processoSeletivo.Id }, processoSeletivo);
        }

        /// <summary>
        /// Atualiza os dados de um processo seletivo existente.
        /// </summary>
        /// <param name="id">ID do processo seletivo a ser atualizado.</param>
        /// <param name="processoSeletivo">Dados atualizados do processo seletivo.</param>
        /// <response code="204">Se a atualização for bem-sucedida.</response>
        /// <response code="400">Se o ID do processo seletivo não corresponder ao informado ou se os dados forem inválidos.</response>
        /// <response code="404">Se o processo seletivo não for encontrado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoSeletivo(int id, ProcessoSeletivo processoSeletivo)
        {
            if (id != processoSeletivo.Id)
            {
                return BadRequest(new { Message = "ID do Processo Seletivo não corresponde." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(processoSeletivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoSeletivoExists(id))
                {
                    return NotFound(new { Message = "Processo Seletivo não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um processo seletivo pelo ID.
        /// </summary>
        /// <param name="id">ID do processo seletivo a ser excluído.</param>
        /// <response code="204">Se a exclusão for bem-sucedida.</response>
        /// <response code="404">Se o processo seletivo não for encontrado.</response>
        /// <response code="400">Se o processo seletivo estiver associado a uma ou mais inscrições.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessoSeletivo(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoSeletivo == null)
            {
                return NotFound(new { Message = "Processo Seletivo não encontrado." });
            }

            // Verifica se o processo seletivo está associado a alguma inscrição
            bool processoAssociado = _context.Inscricoes.Any(i => i.ProcessoSeletivoId == id);
            if (processoAssociado)
            {
                return BadRequest(new { Message = "Não é possível excluir o Processo Seletivo, pois ele está associado a uma ou mais inscrições." });
            }

            _context.ProcessosSeletivos.Remove(processoSeletivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Verifica se um processo seletivo com o ID fornecido existe.
        /// </summary>
        /// <param name="id">ID do processo seletivo.</param>
        /// <returns>Verdadeiro se o processo seletivo existir; caso contrário, falso.</returns>
        private bool ProcessoSeletivoExists(int id)
        {
            return _context.ProcessosSeletivos.Any(e => e.Id == id);
        }
    }
}
