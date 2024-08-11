using Microsoft.AspNetCore.Mvc;
using System.Data;
using Teste.Data;
using Teste.Models;

    public class ProcessoSeletivoController : Controller
{
    readonly private ApplicationDbContext _db;

    public ProcessoSeletivoController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<ProcessoSeletivo> processoSeletivos = _db.ProcessosSeletivos;
        return View(processoSeletivos);
    }

    public IActionResult 
        Cadastrar()
    {
        return View();
    }

  

    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        ProcessoSeletivo ProcessoSeletivo = _db.ProcessosSeletivos.FirstOrDefault(x => x.IdProcessoSeletivo == id);

        if (ProcessoSeletivo == null)
        {
            return NotFound();
        }


        return View(ProcessoSeletivo);

    }
    private DataTable GetDados()
    {

        DataTable dataTable = new DataTable();

        dataTable.TableName = "Processo Seletivo";


        dataTable.Columns.Add("Nome", typeof(string));
        dataTable.Columns.Add("Data de Inicio", typeof(DateTime));
        dataTable.Columns.Add("Data de Termino", typeof(DateTime));


        var dados = _db.ProcessosSeletivos.ToList();

        if (dados.Count > 0)

        {
            dados.ForEach(processoSeletivos =>
            {
                dataTable.Rows.Add(processoSeletivos.Nome, processoSeletivos.DataDeInicio, processoSeletivos.DataDeTermino);
            });
        }

        return dataTable;
    }


    [HttpPost]
    public IActionResult Cadastrar (ProcessoSeletivo processoSeletivos)
    {
        if (ModelState.IsValid)
        {
            _db.ProcessosSeletivos.Add(processoSeletivos);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

            return RedirectToAction("Index");
        }

        return View();

    }

    [HttpPost]
    public IActionResult Editar(ProcessoSeletivo processoSeletivos)
    {
        if (ModelState.IsValid)
        {
            var ProcessoSeletivoDB = _db.ProcessosSeletivos.Find(processoSeletivos.IdProcessoSeletivo);


            ProcessoSeletivoDB.Nome = processoSeletivos.Nome;
            ProcessoSeletivoDB.DataDeInicio = processoSeletivos.DataDeInicio;
            ProcessoSeletivoDB.DataDeTermino = processoSeletivos.DataDeTermino;


            _db.ProcessosSeletivos.Update(ProcessoSeletivoDB);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

            return RedirectToAction("Index");
        }

        TempData["MensagemErro"] = "Ocorreu algum erro no momento da edição!";
        return View(processoSeletivos);
    }

    [HttpPost]
    public IActionResult Excluir(ProcessoSeletivo processosSeletivos)
    {
        if (processosSeletivos == null)
        {
            return NotFound();
        }

        _db.ProcessosSeletivos.Remove(processosSeletivos);
        _db.SaveChanges();
        TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
        return RedirectToAction("Index");

    }



}
