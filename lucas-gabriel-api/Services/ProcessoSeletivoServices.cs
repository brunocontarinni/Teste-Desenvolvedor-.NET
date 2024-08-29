using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace lucas_gabriel_api.Services;

public class ProcessoSeletivoServices
{

    private DatabaseContext _context;

    public ProcessoSeletivoServices(DatabaseContext context)
    {
        this._context = context;
    }


    public async Task<List<ProcessoSeletivo>> ListProcessoService()
    {
        try
        {
            List<ProcessoSeletivo> processosSeletivos = await this._context.ProcessoSeletivos.ToListAsync();

            return processosSeletivos;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "list-processo-seletivo-service-error");
        }
    }

    public async Task<ProcessoSeletivo> GetProcessoSeletivoByIdService(int processoSeletivoId)
    {
        try
        {
            ProcessoSeletivo? processoSeletivo = await this.getProcessoSeletivoById(processoSeletivoId);

            return processoSeletivo!;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "get-processo-seletivo-service-error");
        }
    }

    public async Task<ProcessoSeletivo> CreateProcessoSeletivoService(ProcessoSeletivo processoSeletivoData)
    {
        try
        {
            ProcessoSeletivo createdProcessoSeletivo = (await this._context.AddAsync<ProcessoSeletivo>(processoSeletivoData)).Entity;
            await this._context.SaveChangesAsync();

            return createdProcessoSeletivo;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "create-processo-seletivo-service-error");
        }
    }


    public async Task<ProcessoSeletivo?> UpdateProcessoSeletivoService(ProcessoSeletivo processoSeletivoData)
    {
        try
        {
            ProcessoSeletivo? processoSeletivo = await this.getProcessoSeletivoById(processoSeletivoData.Id);
            this._context.Entry<ProcessoSeletivo>(processoSeletivo!).CurrentValues.SetValues(processoSeletivoData);

            await this._context.SaveChangesAsync();

            return processoSeletivo;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "update-processo-seletivo-service-error");
        }
    }

    public async Task<ProcessoSeletivo?> DeleteProcessoSeletivoService(int processoSeletivoId)
    {
        try
        {

            ProcessoSeletivo? processoSeletivo = await this.getProcessoSeletivoById(processoSeletivoId);
            this._context.ProcessoSeletivos.Remove(processoSeletivo!);
            await this._context.SaveChangesAsync();

            return processoSeletivo;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "delete-processo-seletivo-service-error");
        }
    }

    private async Task<ProcessoSeletivo?> getProcessoSeletivoById(int id)
    {
        return await this._context.FindAsync<ProcessoSeletivo>(id);
    }

}