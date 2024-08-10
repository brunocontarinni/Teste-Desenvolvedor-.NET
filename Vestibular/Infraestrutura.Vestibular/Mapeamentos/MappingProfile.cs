using AutoMapper;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Mapeamentos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidato, CandidatoDto>();
            CreateMap<CandidatoDto, Candidato>();
            CreateMap<Inscricao, InscricaoDto>();
            CreateMap<InscricaoDto, Inscricao>();
            CreateMap<Oferta, OfertaDto>();
            CreateMap<OfertaDto, Oferta>();
            CreateMap<ProcessoSeletivo, ProcessoSeletivoDto>();
            CreateMap<ProcessoSeletivoDto, ProcessoSeletivo>();

            //Mapping modelView
            CreateMap<Candidato, CandidatoModelView>();
            CreateMap<CandidatoModelView, Candidato>();
            CreateMap<Inscricao, InscricaoModelView>();
            CreateMap<InscricaoModelView, Inscricao>();
            CreateMap<Oferta, OfertaModelView>();
            CreateMap<OfertaModelView, Oferta>();
            CreateMap<ProcessoSeletivo, ProcessoSeletivoModelView>();
            CreateMap<ProcessoSeletivoModelView, ProcessoSeletivo>();
        }
    }
}
