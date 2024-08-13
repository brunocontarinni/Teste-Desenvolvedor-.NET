using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using testeCRMEDU.Models;
using testeCRMEDU.Services;

namespace testeCRMEDU.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscricaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inscricoes = _context.Inscricoes.ToList();
            return View(inscricoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inscricao inscricao)
        {
            if (!ModelState.IsValid)
            {
                return View(inscricao);
            }

            if (this.InscricaoExiste(inscricao.Id))
            {
                ModelState.AddModelError("Id", "Já existe uma inscrição com este ID.");

                return View(inscricao);
            }

            _context.Inscricoes.Add(inscricao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Inscricao");
        }

        public IActionResult Edit(string id)
        {
            var inscricao = _context.Inscricoes.Find(id);

            if (inscricao == null)
            {
                return RedirectToAction("Index", "Inscricao");
            }

            return View(inscricao);
        }

        [HttpPost]
        public IActionResult Edit(string id, Inscricao inscricao)
        {
            var inscricaoExistente = _context.Inscricoes.Find(id);

            if (inscricaoExistente == null)
            {
                return RedirectToAction("Index", "Inscricao");
            }

            if (!ModelState.IsValid)
            {
                return View(inscricao);
            }

            inscricaoExistente.NumeroInscricao = inscricao.NumeroInscricao;
            inscricaoExistente.Data = inscricao.Data;
            inscricaoExistente.Status = inscricao.Status;
            inscricaoExistente.LeadId = inscricao.LeadId;
            inscricaoExistente.ProcessoSeletivoId = inscricao.ProcessoSeletivoId;
            inscricaoExistente.OfertaId = inscricao.OfertaId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Inscricao");
        }

        public IActionResult Delete(string id)
        {
            var inscricao = _context.Inscricoes.Find(id);

            if (inscricao == null)
            {
                return RedirectToAction("Index", "Inscricao");
            }

            _context.Inscricoes.Remove(inscricao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Inscricao");
        }

        private bool InscricaoExiste(string id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }

        public IActionResult BuscarPorCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return View();
            }

            var lead = _context.Leads
                .Where(i => i.CPF == cpf)
                .ToList().FirstOrDefault();

            var inscricoes = _context.Inscricoes
                .Where(i => i.LeadId == lead.Id)
                .ToList();


            return View("Index", inscricoes);
        }

        public IActionResult BuscarPorOferta(string ofertaId)
        {
            if (string.IsNullOrEmpty(ofertaId))
            {
                return View();
            }

            var inscricoes = _context.Inscricoes
                .Where(i => i.OfertaId == ofertaId)
                .ToList();

            return View("Index", inscricoes);
        }
    }
}
