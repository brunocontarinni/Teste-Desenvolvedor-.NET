using lucas_gabriel_api.Models;
using lucas_gabriel_api.Models.Entitys;
using lucas_gabriel_api.Resources.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace lucas_gabriel_api.Services;

public class LeadServices
{

    private DatabaseContext _context;

    public LeadServices(DatabaseContext context)
    {
        this._context = context;
    }


    public async Task<List<Lead>> ListLeadService()
    {
        try
        {
            List<Lead> leads = await this._context.Leads.ToListAsync();

            return leads;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "list-lead-service-error");
        }
    }

    public async Task<Lead> GetLeadByIdService(int leadId)
    {
        try
        {
            Lead? lead = await this.getLeadById(leadId);

            return lead!;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "get-lead-service-error");
        }
    }

    public async Task<Lead> CreateLeadService(Lead leadData)
    {
        try
        {
            Lead createdLead = (await this._context.AddAsync<Lead>(leadData)).Entity;
            await this._context.SaveChangesAsync();

            return createdLead;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "create-lead-service-error");
        }
    }


    public async Task<Lead?> UpdateLeadService(Lead leadData)
    {
        try
        {
            Lead? lead = await this.getLeadById(leadData.Id);
            this._context.Entry<Lead>(lead!).CurrentValues.SetValues(leadData);

            await this._context.SaveChangesAsync();

            return lead;
        }
        catch (Exception)
        {

            throw new ServiceException(500, "update-lead-service-error");
        }
    }

    public async Task<Lead?> DeleteLeadService(int leadId)
    {
        try
        {

            Lead? lead = await this.getLeadById(leadId);
            this._context.Leads.Remove(lead!);
            await this._context.SaveChangesAsync();

            return lead;
        }
        catch (Exception)
        {
            throw new ServiceException(500, "delete-lead-service-error");
        }
    }

    private async Task<Lead?> getLeadById(int id)
    {
        return await this._context.FindAsync<Lead>(id);
    }

}