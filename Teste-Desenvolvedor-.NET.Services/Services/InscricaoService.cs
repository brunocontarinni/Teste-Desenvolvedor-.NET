
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public InscricaoService(IMapper mapper, DBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        // Adiciona uma Inscrição
        public async Task<Inscricao> AdicionarInscricao(InscricaoModel model)
        {
            //Mapeia o modelo para uma inscrição
            var inscricao = _mapper.Map<Inscricao>(model);

            //Busca o Lead respectino no banco de dados
            inscricao.Lead = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == inscricao.IdLead);

            //Busca a respectiva Oferta no banco de dados
            inscricao.Oferta = await _dbContext.Ofertas.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == inscricao.IdOferta);

            //Busca o respectivo Processo Seletivo no banco de dados
            inscricao.ProcessoSeletivo = await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == inscricao.IdProcessoSeletivo);

            //Verifica se a inscrição é valida
            inscricao.IsValid();

            // retorna se a inscrição ter alguma notificação
            if (inscricao.Notificacao.Any())
            {
                return inscricao;
            }
            //Salva nova inscrição no banco
            await _dbContext.Inscricoes.AddAsync(inscricao);
            await _dbContext.SaveChangesAsync();
            return inscricao;
        }


        public async Task<Inscricao> AtualizarInscricao(Guid id, InscricaoModel model)
        {
            //Mapeia o modelo para a Entidade
            var inscricao = _mapper.Map<Inscricao>(model);

            // Verifica se a Inscrição existe no banco 
            var existe = await _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            // Retorna nulo caso nao encontrar
            if (existe == null)
            {
                return null;
            }
            // Atualiza a Entidade
            existe.Atualizar(inscricao.Nome,inscricao.Status,inscricao.IdOferta,inscricao.IdLead,inscricao.IdProcessoSeletivo);
            // Verifica se à alguma Notificação e retorna se sim
            if (existe.Notificacao.Any())
            {
                return existe;
            }
            // Salva as alterações no banco de dados
            _dbContext.Inscricoes.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarInscricao(Guid id)
        {
            // Verifica se a Inscrição existe
            var inscricao = await _dbContext.Inscricoes.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);

            // retorna falso caso nao existir
            if (inscricao == null)
            {
                return false;
            }
            // seta a propriedade deletado para true
            inscricao.Delete();
            // salva as alterações no banco
            _dbContext.Inscricoes.Update(inscricao);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Inscricao>> GetAllInscricao()
        {
            //Retorna uma lista com todas as Inscrições com seus respectivos Leads, Processo Seletivos e Ofertas
            return await _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<Inscricao>> GetInscicoesCPF(string cpf)
        {
            //Verifica se o CPF Existe
            var lead = await _dbContext.Leads.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.CPF == cpf);
            // Retorna nulo se não existir
            if (lead == null)
            {
                return null;
            }

            // Busca a Inscrição com aquele CPF com seus respectivos Leads, Processo Seletivos e Ofertas
            var inscricoes = await _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == false)
                .Where(x => x.IdLead == lead.Id).ToListAsync();
            // Retorna uma Lista de Inscrições
            return inscricoes;
        }

        public async Task<IEnumerable<Inscricao>> GetInscicoesOferta(Guid id)
        {
            // Retorna uma lista de Inscrições com seus respectivos Leads, Processo Seletivos e Ofertas baseado no ID da Oferta
            return await  _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == false)
                .Where(x => x.IdOferta == id).ToListAsync();
        }

        public async Task<Inscricao> GetInscricao(Guid id)
        {
            // Retorna uma inscrção com seus respectivos Leads, Processo Seletivos e Ofertas baseado no ID da Inscrição
            return await _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
    
    
}
