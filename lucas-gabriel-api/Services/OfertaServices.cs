using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace lucas_gabriel_api.Services;

public class OfertaServices
{

    private DatabaseContext _context;

    public OfertaServices(DatabaseContext context)
    {
        this._context = context;
    }


    public async Task<List<Oferta>> ListOfertaService()
    {
        try
        {
            List<Oferta> leads = await this._context.Ofertas.ToListAsync();

            return leads;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "list-oferta-service-error");
        }
    }

    public async Task<Oferta> GetOfertaByIdService(int ofertaId)
    {
        try
        {
            Oferta? oferta = await this.getOfertaById(ofertaId);

            return oferta!;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "get-oferta-service-error");
        }
    }

    public async Task<Oferta> CreateOfertaService(Oferta ofertaData)
    {
        try
        {
            Oferta createdOferta = (await this._context.AddAsync<Oferta>(ofertaData)).Entity;
            await this._context.SaveChangesAsync();

            return createdOferta;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "create-oferta-service-error");
        }
    }


    public async Task<Oferta?> UpdateOfertaService(Oferta ofertaData)
    {
        try
        {
            Oferta? oferta = await this.getOfertaById(ofertaData.Id);
            this._context.Entry<Oferta>(oferta!).CurrentValues.SetValues(ofertaData);

            await this._context.SaveChangesAsync();

            return oferta;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "update-oferta-service-error");
        }
    }

    public async Task<Oferta?> DeleteOfertaService(int ofertaId)
    {
        try
        {

            Oferta? oferta = await this.getOfertaById(ofertaId);
            this._context.Ofertas.Remove(oferta!);
            await this._context.SaveChangesAsync();

            return oferta;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "delete-oferta-service-error");
        }
    }

    private async Task<Oferta?> getOfertaById(int id)
    {
        return await this._context.FindAsync<Oferta>(id);
    }

}