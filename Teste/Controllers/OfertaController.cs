
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Teste.Data;
using Teste.Models;

public class OfertaController : Controller
{
    readonly private ApplicationDbContext _db;

    public OfertaController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Oferta> Ofertas = _db.Ofertas;
        return View(Ofertas);
    }

    public IActionResult
        Cadastrar()
    {
        return View();
    }

    public IActionResult Editar(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Oferta Oferta = _db.Ofertas.FirstOrDefault(x => x.IdOferta == id);

        if (Oferta == null)
        {
            return NotFound();
        }


        return View(Oferta);
    }

    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        Oferta Oferta = _db.Ofertas.FirstOrDefault(x => x.IdOferta == id);

        if (Oferta == null)
        {
            return NotFound();
        }


        return View(Oferta);

    }
    private DataTable GetDados()
    {

        DataTable dataTable = new DataTable();

        dataTable.TableName = "Oferta";


        dataTable.Columns.Add("Nome", typeof(string));
        dataTable.Columns.Add("Descriçao", typeof(string));
        dataTable.Columns.Add("Vagas Disponiveis", typeof(int));


        var dados = _db.Ofertas.ToList();

        if (dados.Count > 0)

        {
            dados.ForEach(Ofertas =>
            {
                dataTable.Rows.Add(Ofertas.Nome, Ofertas.Descricao, Ofertas.Vagas);
            });
        }

        return dataTable;
    }


    [HttpPost]
    public IActionResult Cadastrar(Oferta Ofertas)
    {
        if (ModelState.IsValid)
        {
            _db.Ofertas.Add(Ofertas);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index");
        }

        return View();

    }

    [HttpPost]
    public IActionResult Editar(Oferta Ofertas)
    {
        if (ModelState.IsValid)
        {
            var OfertaDB = _db.Ofertas.Find(Ofertas.IdOferta);


            OfertaDB.Nome = Ofertas.Nome;
            OfertaDB.Descricao = Ofertas.Descricao;
            OfertaDB.Vagas = Ofertas.Vagas;


            _db.Ofertas.Update(OfertaDB);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

            return RedirectToAction("Index");
        }

        TempData["MensagemErro"] = "Ocorreu algum erro no momento da edição!";
        return View(Ofertas);
    }

    [HttpPost]
    public IActionResult Excluir(Oferta Ofertas)
    {
        if (Ofertas == null)
        {
            return NotFound();
        }

        _db.Ofertas.Remove(Ofertas);
        _db.SaveChanges();
        TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
        return RedirectToAction("Index");

    }



}
