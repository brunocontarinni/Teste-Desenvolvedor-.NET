using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            // Mapeia o modelo para a Entidade de Dominio
            var oferta = _mapper.Map<Oferta>(model);

            // Caso tenha alguma notificação retorne
            if (oferta.Notificacao.Any())
            {
                return oferta;
            }

            // Salva a nova oferta no banco de dados
            await _dbContext.Ofertas.AddAsync(oferta);
            await _dbContext.SaveChangesAsync();
            return oferta;
        }

        public async Task<Oferta> AtualizarOferta(Guid id, OfertaModel model)
        {
            // Mapeia o modelo para a Entidade
            var oferta = _mapper.Map<Oferta>(model);

            // Procura a Oferta no banco de dados
            var existe = await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);

            // Retorna nulo se nao encontrar
            if (existe == null)
            {
                return null;
            }

            // Atualiza as prorpiedades da entidade
            existe.Atualizar(oferta.Nome,oferta.Descricao,oferta.VagasDisponiveis);

            // Verifica se ha alguma notificação, caso sim retorne
            if (existe.Notificacao.Any())
            {
                return existe;
            }

            // Salva as alterações no banco de dados
            _dbContext.Ofertas.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarOferta(Guid id)
        {
            // Procura a Oferta no banco de dados
            var oferta = await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);

            // Se nao encotrar retorne nulo
            if(oferta == null)
            {
                return false;
            }

            // Atualiza a flag de deleção para true
            oferta.Delete();
            // Salva a alteração no banco
            _dbContext.Ofertas.Update(oferta);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Oferta>> GetAllOferta()
        {
            // Retorna todas as Ofertas não deletadas
            return await _dbContext.Ofertas.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<Oferta> GetOferta(Guid id)
        {
            // Retorna uma oferta não deletada baseada no Id
            return await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
