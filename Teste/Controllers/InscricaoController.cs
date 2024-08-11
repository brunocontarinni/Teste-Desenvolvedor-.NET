using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Teste.Data;
using Teste.Models;

public class InscricaoController : Controller
{
    readonly private ApplicationDbContext _db;

    public InscricaoController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Inscricao> Inscricoes = _db.Inscricoes;
        return View(Inscricoes);
    }

    public IActionResult Cadastrar()
    {
        ViewBag.Leads = _db.Leads.ToList();
        ViewBag.Ofertas = _db.Ofertas.ToList();
        ViewBag.ProcessosSeletivos = _db.ProcessosSeletivos.ToList();
        return View();
    }

    public IActionResult Editar(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Inscricao inscricao = _db.Inscricoes
            .Include(i => i.Lead)
            .Include(i => i.Oferta)
            .Include(i => i.ProcessoSeletivo)
            .FirstOrDefault(x => x.IdInscricao == id);

        if (inscricao == null)
        {
            return NotFound();
        }

        ViewBag.Leads = _db.Leads.ToList();
        ViewBag.Ofertas = _db.Ofertas.ToList();
        ViewBag.ProcessosSeletivos = _db.ProcessosSeletivos.ToList();
        return View(inscricao);
    }

    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Inscricao inscricao = _db.Inscricoes
            .Include(i => i.Lead)
            .Include(i => i.Oferta)
            .Include(i => i.ProcessoSeletivo)
            .FirstOrDefault(x => x.IdInscricao == id);

        if (inscricao == null)
        {
            return NotFound();
        }

        return View(inscricao);
    }

    private DataTable GetDados()
    {
        DataTable dataTable = new DataTable();
        dataTable.TableName = "Inscricao";

        dataTable.Columns.Add("Numero", typeof(int));
        dataTable.Columns.Add("Data", typeof(DateTime));
        dataTable.Columns.Add("Status", typeof(string));
        dataTable.Columns.Add("Lead", typeof(string));
        dataTable.Columns.Add("Oferta", typeof(string));
        dataTable.Columns.Add("Processo Seletivo", typeof(string));

        var dados = _db.Inscricoes.Include(i => i.Lead)
                                   .Include(i => i.Oferta)
                                   .Include(i => i.ProcessoSeletivo)
                                   .ToList();

        if (dados.Count > 0)
        {
            dados.ForEach(inscricao =>
            {
                dataTable.Rows.Add(inscricao.Numero, inscricao.Data, inscricao.Status,
                                   inscricao.Lead.Nome, inscricao.Oferta.Nome,
                                   inscricao.ProcessoSeletivo.Nome);
            });
        }

        return dataTable;
    }

    [HttpPost]
    public IActionResult Cadastrar(Inscricao inscricao)
    {
        if (ModelState.IsValid)
        {
            _db.Inscricoes.Add(inscricao);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Index");
        }

        ViewBag.Leads = _db.Leads.ToList();
        ViewBag.Ofertas = _db.Ofertas.ToList();
        ViewBag.ProcessosSeletivos = _db.ProcessosSeletivos.ToList();
        return View(inscricao);
    }

    [HttpPost]
    public IActionResult Editar(Inscricao inscricao)
    {
        if (ModelState.IsValid)
        {
            var inscricaoDB = _db.Inscricoes.Find(inscricao.IdInscricao);

            if (inscricaoDB == null)
            {
                return NotFound();
            }

            inscricaoDB.Numero = inscricao.Numero;
            inscricaoDB.Data = inscricao.Data;
            inscricaoDB.Status = inscricao.Status;
            inscricaoDB.IdLead = inscricao.IdLead;
            inscricaoDB.IdOferta = inscricao.IdOferta;
            inscricaoDB.IdProcessoSeletivo = inscricao.IdProcessoSeletivo;

            _db.Inscricoes.Update(inscricaoDB);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
            return RedirectToAction("Index");
        }

        TempData["MensagemErro"] = "Ocorreu algum erro no momento da edição!";
        ViewBag.Leads = _db.Leads.ToList();
        ViewBag.Ofertas = _db.Ofertas.ToList();
        ViewBag.ProcessosSeletivos = _db.ProcessosSeletivos.ToList();
        return View(inscricao);
    }

    [HttpPost]
    public IActionResult Excluir(Inscricao inscricao)
    {
        if (inscricao == null)
        {
            return NotFound();
        }

        _db.Inscricoes.Remove(inscricao);
        _db.SaveChanges();
        TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
        return RedirectToAction("Index");
    }
}