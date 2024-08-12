
using AutoMapper;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.Domain.Profiles
{
    public class TesteProfiles : Profile
    {
        public TesteProfiles()
        {
            CreateMap<InscricaoModel, Inscricao>();
            CreateMap<LeadModel, Lead>();
            CreateMap<OfertaModel, Oferta>();
            CreateMap<ProcessoSeletivoModel, ProcessoSeletivo>();

            CreateMap<Inscricao, InscricaoModel>();
            CreateMap<Lead, LeadModel>();
            CreateMap<Oferta, OfertaModel>();
            CreateMap<ProcessoSeletivo, ProcessoSeletivoModel>();
        }
    }
}
