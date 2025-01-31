using Microsoft.AspNetCore.Mvc;
using VestibularApi.Domain.Entities;
using VestibularApi.Infrastructure;

namespace VestibularApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcessoSeletivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var processos = _context.ProcessosSeletivos.ToList();
            return Ok(processos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var processo = _context.ProcessosSeletivos.Find(id);

            if(processo == null)
                return NotFound();

            return Ok(processo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProcessoSeletivo processo)
        {
            _context.ProcessosSeletivos.Add(processo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = processo.Id }, processo);
        }

        [HttpPut("{id}")]
        public IActionResult Uptade(int id, [FromBody] ProcessoSeletivo updateProcesso)
        {
            var processo = _context.ProcessosSeletivos.Find(id);
            if (processo == null)
                return NotFound();

            processo.Nome = updateProcesso.Nome;
            processo.DataInicio = updateProcesso.DataInicio;
            processo.DataTermino = updateProcesso.DataTermino;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var processo = _context.ProcessosSeletivos.Find(id);
            if (processo == null)
                return NotFound();

            _context.ProcessosSeletivos.Remove(processo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
