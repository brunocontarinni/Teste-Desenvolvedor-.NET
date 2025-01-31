using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class InscricaoService
{
    private readonly VestTestDbContext _context;

    public InscricaoService(VestTestDbContext context)
    {
        _context = context;
    }

    // Método para obter todas as inscrições
    public IEnumerable<InscricaoDTO> GetAll()
    {
        return _context.Inscricoes
            .Select(i => new InscricaoDTO
            {
                Id = i.Id,
                NumeroInscricao = i.NumeroInscricao,
                Data = i.Data,
                Status = i.Status,
                CandidatoId = i.CandidatoId,
                ProcessoSeletivoId = i.ProcessoSeletivoId,
                OfertaCursoId = i.OfertaCursoId
            })
            .ToList();
    }

    public async Task<InscricaoDTO> GetById(int id)
    {
        var inscricao = await _context.Inscricoes
            .Where(i => i.Id == id)
            .Include(i => i.Candidato)
            .Include(i => i.ProcessoSeletivo)
            .Include(i => i.OfertaCurso)
            .FirstOrDefaultAsync();

        if (inscricao == null)
        {
            return null;
        }

        return new InscricaoDTO
        {
            Id = inscricao.Id,
            NumeroInscricao = inscricao.NumeroInscricao,
            Data = inscricao.Data,
            Status = inscricao.Status,
            CandidatoId = inscricao.CandidatoId,
            CandidatoNome = inscricao.Candidato?.Nome,
            CandidatoCpf = inscricao.Candidato?.CPF,
            ProcessoSeletivoId = inscricao.ProcessoSeletivoId,
            ProcessoSeletivoNome = inscricao.ProcessoSeletivo?.Nome,
            OfertaCursoId = inscricao.OfertaCursoId,
            OfertaCursoNome = inscricao.OfertaCurso?.Nome
        };
    }

    public async Task<Inscricao> TesteCarregamento(int id)
    {
        var inscricao = await _context.Inscricoes
            .Where(i => i.Id == id)
            .Include(i => i.Candidato)
            .Include(i => i.ProcessoSeletivo)
            .Include(i => i.OfertaCurso)
            .FirstOrDefaultAsync();

        if (inscricao == null)
        {
            return null;
        }

        return inscricao;
    }

    public InscricaoDTO Create(InscricaoDTO inscricaoDto)
    {
        var inscricao = new Inscricao
        {
            NumeroInscricao = inscricaoDto.NumeroInscricao,
            Data = inscricaoDto.Data,
            Status = inscricaoDto.Status,
            CandidatoId = inscricaoDto.CandidatoId,
            ProcessoSeletivoId = inscricaoDto.ProcessoSeletivoId,
            OfertaCursoId = inscricaoDto.OfertaCursoId
        };

        _context.Inscricoes.Add(inscricao);
        _context.SaveChanges();

        inscricaoDto.Id = inscricao.Id;
        return inscricaoDto;
    }

    public InscricaoDTO Update(int id, InscricaoDTO inscricaoDto)
    {
        var inscricao = _context.Inscricoes.Find(id);

        if (inscricao == null)
        {
            return null;
        }

        inscricao.NumeroInscricao = inscricaoDto.NumeroInscricao;
        inscricao.Data = inscricaoDto.Data;
        inscricao.Status = inscricaoDto.Status;
        inscricao.CandidatoId = inscricaoDto.CandidatoId;
        inscricao.ProcessoSeletivoId = inscricaoDto.ProcessoSeletivoId;
        inscricao.OfertaCursoId = inscricaoDto.OfertaCursoId;

        _context.SaveChanges();

        return inscricaoDto;
    }

    public bool Delete(int id)
    {
        var inscricao = _context.Inscricoes.Find(id);

        if (inscricao == null)
        {
            return false;
        }

        _context.Inscricoes.Remove(inscricao);
        _context.SaveChanges();

        return true;
    }

    public async Task<List<InscricaoDTO>> ObterInscricoesPorCpfAsync(string cpf)
    {
        var inscricoes = await _context.Inscricoes
            .Where(i => i.Candidato.CPF == cpf)
            .Include(i => i.ProcessoSeletivo)
            .ToListAsync();

        var inscricoesDTO = inscricoes.Select(i => new InscricaoDTO
        {
            Id = i.Id,
            NumeroInscricao = i.NumeroInscricao,
            Data = i.Data,
            Status = i.Status,
            CandidatoId = i.CandidatoId,
            ProcessoSeletivoId = i.ProcessoSeletivoId,
            ProcessoSeletivoNome = i.ProcessoSeletivo.Nome,
        }).ToList();

        return inscricoesDTO;
    }
}
