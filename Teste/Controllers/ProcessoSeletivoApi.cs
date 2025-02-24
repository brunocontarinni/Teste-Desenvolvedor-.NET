using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoApiController : ControllerBase
    {
        private readonly Contexto _context;

        private readonly ILogger<ProcessoSeletivoApiController> _logger;

        public ProcessoSeletivoApiController(ILogger<ProcessoSeletivoApiController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<ProcessoSeletivoApiController>
        [HttpGet]
        public async Task<IEnumerable<ProcessoSeletivo>> Get()
        {
            return await _context.ProcessosSeletivos.ToListAsync();
        }

        // GET api/<ProcessoSeletivoApiController>/5
        [HttpGet("{id}")]
        public Task<ProcessoSeletivo> Get(int id)
        {
            var processo = _context.ProcessosSeletivos.Find(id);
            return Task.FromResult<ProcessoSeletivo>(processo);
        }

        // POST api/<ProcessoSeletivoApiController>
        [HttpPost]
        public async Task Post([FromBody] ProcessoSeletivo value)
        {
            if (ModelState.IsValid)
            {
                _context.ProcessosSeletivos.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/<ProcessoSeletivoApiController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProcessoSeletivo value)
        {
            if (ModelState.IsValid)
            {
                _context.ProcessosSeletivos.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/<ProcessoSeletivoApiController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var processo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processo != null)
            {
                _context.ProcessosSeletivos.Remove(processo);
            }

            await _context.SaveChangesAsync();
        }
    }
}
