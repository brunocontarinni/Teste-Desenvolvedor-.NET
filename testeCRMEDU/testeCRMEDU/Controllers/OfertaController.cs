using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using testeCRMEDU.Models;
using testeCRMEDU.Models.Dtos;
using testeCRMEDU.Services;

namespace testeCRMEDU.Controllers
{
    public class OfertaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfertaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ofertas = _context.Ofertas.ToList();
            return View(ofertas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Oferta oferta)
        {
            if (!ModelState.IsValid)
            {
                return View(oferta);
            }

            if (this.OfertaExiste(oferta.Id))
            {
                ModelState.AddModelError("Id", "Já existe uma oferta com este ID.");

                return View(oferta);
            }

            _context.Ofertas.Add(oferta);
            _context.SaveChanges();

            return RedirectToAction("Index", "Oferta");
        }

        public IActionResult Edit(string id)
        {
            var oferta = _context.Ofertas.Find(id);

            if (oferta == null)
            {
                return RedirectToAction("Index", "Oferta");
            }

            return View(oferta);
        }

        [HttpPost]
        public IActionResult Edit(string id, Oferta oferta)
        {
            var ofertaExistente = _context.Ofertas.Find(id);

            if (ofertaExistente == null)
            {
                return RedirectToAction("Index", "Oferta");
            }

            if (!ModelState.IsValid)
            {
                return View(oferta);
            }

            ofertaExistente.Nome = oferta.Nome;
            ofertaExistente.Descricao = oferta.Descricao;
            ofertaExistente.VagasDisponiveis = oferta.VagasDisponiveis;

            _context.SaveChanges();

            return RedirectToAction("Index", "Oferta");
        }

        public IActionResult Delete(string id)
        {
            var oferta = _context.Ofertas.Find(id);

            if (oferta == null)
            {
                return RedirectToAction("Index", "Oferta");
            }

            _context.Ofertas.Remove(oferta);
            _context.SaveChanges();

            return RedirectToAction("Index", "Oferta");
        }

        private bool OfertaExiste(string id)
        {
            return _context.Ofertas.Any(e => e.Id == id);
        }
    }
}
