using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class OfertaServices : IOfertaService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public OfertaServices(IMapper mapper, DBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Oferta> AdicionarOferta(OfertaModel model)
        {
            var oferta = _mapper.Map<Oferta>(model);

            if (oferta.Notificacao.Any())
            {
                return oferta;
            }

            await _dbContext.Ofertas.AddAsync(oferta);
            await _dbContext.SaveChangesAsync();
            return oferta;
        }

        public async Task<Oferta> AtualizarOferta(Guid id, OfertaModel model)
        {
            var oferta = _mapper.Map<Oferta>(model);
            var existe = await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (existe == null)
            {
                return null;
            }

            existe.Atualizar(oferta.Nome,oferta.Descricao,oferta.VagasDisponiveis);

            if (existe.Notificacao.Any())
            {
                return existe;
            }

            _dbContext.Ofertas.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarOferta(Guid id)
        {
            var oferta = await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if(oferta == null)
            {
                return false;
            }

            oferta.Delete();
            _dbContext.Ofertas.Update(oferta);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Oferta>> GetAllOferta()
        {
            return await _dbContext.Ofertas.ToListAsync();
        }

        public async Task<Oferta> GetOferta(Guid id)
        {
            return await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
