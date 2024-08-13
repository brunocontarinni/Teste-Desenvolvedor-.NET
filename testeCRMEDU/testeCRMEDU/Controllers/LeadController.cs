using System.Linq;
using Microsoft.AspNetCore.Mvc;
using testeCRMEDU.Models;
using testeCRMEDU.Services;

namespace testeCRMEDU.Controllers
{
    public class LeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var leads = _context.Leads.ToList();
            return View(leads);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return View(lead);
            }

            if (this.LeadExiste(lead.Id))
            {
                ModelState.AddModelError("Id", "Já existe uma lead com este ID.");

                return View(lead);
            }

            _context.Leads.Add(lead);
            _context.SaveChanges();

            return RedirectToAction("Index", "Lead");
        }

        public IActionResult Edit(string id)
        {
            var lead = _context.Leads.Find(id);

            if (lead == null)
            {
                return RedirectToAction("Index", "Lead");
            }

            return View(lead);
        }

        [HttpPost]
        public IActionResult Edit(string id, Lead lead)
        {
            var leadExistente = _context.Leads.Find(id);

            if (leadExistente == null)
            {
                return RedirectToAction("Index", "Lead");
            }

            if (!ModelState.IsValid)
            {
                return View(lead);
            }

            leadExistente.Nome = lead.Nome;
            leadExistente.Email = lead.Email;
            leadExistente.Telefone = lead.Telefone;
            leadExistente.CPF = lead.CPF;

            _context.SaveChanges();

            return RedirectToAction("Index", "Lead");
        }

        public IActionResult Delete(string id)
        {
            var lead = _context.Leads.Find(id);

            if (lead == null)
            {
                return RedirectToAction("Index", "Lead");
            }

            _context.Leads.Remove(lead);
            _context.SaveChanges();

            return RedirectToAction("Index", "Lead");
        }

        private bool LeadExiste(string id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
