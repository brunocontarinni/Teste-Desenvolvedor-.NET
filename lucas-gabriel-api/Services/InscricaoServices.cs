using System.Linq.Expressions;
using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace lucas_gabriel_api.Services;

public class InscricaoServices
{
    private DatabaseContext _context;

    public InscricaoServices(DatabaseContext context)
    {
        this._context = context;
    }

    public async Task<List<Inscricao>> ListInscricaoService()
    {
        try
        {
            List<Inscricao> inscricoes = await this._context.Inscricoes.ToListAsync<Inscricao>();

            return inscricoes;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "list-inscricao-service-error");
        }
    }

    public async Task<Inscricao> GetInscricaoByIdService(int inscricaoId)
    {
        try
        {
            Inscricao? inscricao = await this._context.Inscricoes.
                        Include(ins => ins.Lead).
                        Include(ins => ins.Oferta).
                        Include(ins => ins.ProcessoSeletivo).
                        FirstOrDefaultAsync(b => b.Id == inscricaoId);

            return inscricao!;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "get-inscricao-service-error");
        }
    }

    public async Task<Inscricao> CreateInscricaoService(Inscricao inscricaoData)
    {
        try
        {
            Inscricao createdInscricao = (await this._context.Inscricoes.AddAsync(inscricaoData)).Entity;
            await this._context.SaveChangesAsync();

            return createdInscricao;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "create-insrcicao-service-error");
        }
    }

    public async Task<Inscricao?> UpdateInscricaoService(Inscricao inscricaoData)
    {
        try
        {
            Inscricao? inscricao = await this.getInscricaoById(inscricaoData.Id);
            this._context.Entry<Inscricao>(inscricao!).CurrentValues.SetValues(inscricaoData);

            await this._context.SaveChangesAsync();

            return inscricao;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "update-inscricao-service-error");
        }
    }

    public async Task<Inscricao?> DeleteInscricaoService(int inscricaoId)
    {
        try
        {
            Inscricao? inscricao = await this.getInscricaoById(inscricaoId);
            this._context.Remove(inscricao!);

            await this._context.SaveChangesAsync();

            return inscricao;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "delete-inscricao-service-error");
        }
    }


    public async Task<List<Inscricao>> GetInscricaoByCpfService(string cpf)
    {
        try
        {
            List<Inscricao> inscricoes = await this._context.Inscricoes
                                                .Include(ins => ins.Lead)
                                                .Include(ins => ins.Oferta)
                                                .Include(ins => ins.ProcessoSeletivo)
                                                .Where(ins => ins.Lead!.Cpf == cpf)
                                                .ToListAsync();
            return inscricoes;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "inscricao-by-cpf-error");
        }
    }

    public async Task<List<Inscricao>> GetInscricaoByOfertaService(int ofertaId)
    {
        Console.WriteLine(ofertaId);
        try
        {
            List<Inscricao> inscricoes = await this._context.Inscricoes
                                                .Where(ins => ins.OfertaId == ofertaId)
                                                .ToListAsync();
            return inscricoes;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "inscricao-by-oferta-error");
        }
    }

    private async Task<Inscricao?> getInscricaoById(int id)
    {
        return await this._context.Inscricoes.FindAsync(id);
    }
}