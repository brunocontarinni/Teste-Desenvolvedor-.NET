using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste;
using Teste.Models;

namespace Teste.Controllers
{
    public class ProcessoSeletivoController : Controller
    {
        private readonly Contexto _context;

        public ProcessoSeletivoController(Contexto context)
        {
            _context = context;
        }

        // GET: ProcessoSeletivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessosSeletivos.ToListAsync());
        }

        // GET: ProcessoSeletivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoSeletivo = await _context.ProcessosSeletivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoSeletivo == null)
            {
                return NotFound();
            }

            return View(processoSeletivo);
        }

        // GET: ProcessoSeletivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessoSeletivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,DataTermino")] ProcessoSeletivo processoSeletivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processoSeletivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processoSeletivo);
        }

        // GET: ProcessoSeletivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoSeletivo == null)
            {
                return NotFound();
            }
            return View(processoSeletivo);
        }

        // POST: ProcessoSeletivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataInicio,DataTermino")] ProcessoSeletivo processoSeletivo)
        {
            if (id != processoSeletivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processoSeletivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoSeletivoExists(processoSeletivo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(processoSeletivo);
        }

        // GET: ProcessoSeletivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processoSeletivo = await _context.ProcessosSeletivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoSeletivo == null)
            {
                return NotFound();
            }

            return View(processoSeletivo);
        }

        // POST: ProcessoSeletivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoSeletivo != null)
            {
                _context.ProcessosSeletivos.Remove(processoSeletivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoSeletivoExists(int id)
        {
            return _context.ProcessosSeletivos.Any(e => e.Id == id);
        }
    }
}
