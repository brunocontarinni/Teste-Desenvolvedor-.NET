using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Controllers;

[ApiController]
[Route("[controller]")]
public class TesteController : ControllerBase
{
    private readonly Contexto _context;

    private readonly ILogger<TesteController> _logger;

    public TesteController(ILogger<TesteController> logger, Contexto context)
    {
        _context = context;
        _logger = logger;
    }


    [HttpGet(Name = "GetLeads")]
    public IEnumerable<Lead> GetLeads()
    {
        var leads = _context.Leads.ToList();
        return leads;
    }
}
