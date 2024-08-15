using Microsoft.EntityFrameworkCore;
using VestibularAPI.Data;
using VestibularAPI.Models;

public class InscricaoRepository
{
    private readonly VestibularContext _context;

    public InscricaoRepository(VestibularContext context)
    {
        _context = context;
    }

    public IEnumerable<Inscricao> GetInscricoesByCpf(string cpf)
    {
        return _context.Inscricoes
                       .Include(i => i.Lead)
                       .Where(i => i.Lead.CPF == cpf)
                       .ToList();
    }

    public IEnumerable<Inscricao> GetInscricoesByOferta(int ofertaId)
    {
        return _context.Inscricoes
                       .Where(i => i.IDOferta == ofertaId)
                       .ToList();
    }
}
