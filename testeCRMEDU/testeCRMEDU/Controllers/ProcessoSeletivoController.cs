using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using testeCRMEDU.Models;
using testeCRMEDU.Models.Dtos;
using testeCRMEDU.Services;

namespace testeCRMEDU.Controllers
{
    public class ProcessoSeletivoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessoSeletivoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var processoSeletivo = _context.ProcessosSeletivos.ToList();
            return View(processoSeletivo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProcessoSeletivoDto processoSeletivoDto)
        {
            if (!ModelState.IsValid)
            {
                return View(processoSeletivoDto);
            }

            if(this.ProcessoSeletivoExiste(processoSeletivoDto.Id))
            {
                ModelState.AddModelError("Id", "Já existe um processo seletivo com este ID.");

                return View(processoSeletivoDto);
            }

            ProcessoSeletivo processoSeletivo = new ProcessoSeletivo()
            {
                Nome = processoSeletivoDto.Nome,
                Id = processoSeletivoDto.Id,
                DataInicio = processoSeletivoDto.DataInicio,
                DataTermino = processoSeletivoDto.DataTermino,
            };

            _context.ProcessosSeletivos.Add(processoSeletivo);
            _context.SaveChanges();

            return RedirectToAction("Index", "ProcessoSeletivo");
        }

        public IActionResult Edit(string id)
        {

            var processoSeletivo = _context.ProcessosSeletivos.Find(id);

            if (processoSeletivo == null)
            {
                return RedirectToAction("Index", "ProcessoSeletivo");
            }

            var processoSeletivoDto = new ProcessoSeletivoDto()
            {
                Nome = processoSeletivo.Nome,
                DataInicio = processoSeletivo.DataInicio,
                DataTermino = processoSeletivo.DataTermino,
            };

            ViewData["ProcessoSeletivoId"] = processoSeletivo.Id;

            return View(processoSeletivoDto);
        }

        [HttpPost]
        public IActionResult Edit(string id, ProcessoSeletivoDto processoSeletivoDto)
        {
            var processoSeletivo = _context.ProcessosSeletivos.Find(id);

            if (processoSeletivo == null)
            {
                return RedirectToAction("Index", "ProcessoSeletivo");
            }

            if (!ModelState.IsValid)
            {
                ViewData["Id"] = processoSeletivo.Id;

                return View(processoSeletivoDto);
            }

            processoSeletivo.Nome = processoSeletivoDto.Nome;
            processoSeletivo.DataInicio = processoSeletivoDto.DataInicio;
            processoSeletivo.DataTermino = processoSeletivoDto.DataTermino;


            _context.SaveChanges();

            return RedirectToAction("Index", "ProcessoSeletivo");
        }

        public IActionResult Delete(string id)
        {
            var processosSeletivo = _context.ProcessosSeletivos.Find(id);

            if (processosSeletivo == null)
            {
                return RedirectToAction("Index", "ProcessoSeletivo");
            }

            _context.ProcessosSeletivos.Remove(processosSeletivo);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "ProcessoSeletivo");
        }

        private bool ProcessoSeletivoExiste(string id)
        {
            return _context.ProcessosSeletivos.Any(e => e.Id == id);
        }
    }
}
