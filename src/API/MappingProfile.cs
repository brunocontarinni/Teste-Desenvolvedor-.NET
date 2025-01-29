using AutoMapper;
using Domain.Entities;
using Application.DTO;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidatoDTO, Candidato>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InscricaoDTO, Inscricao>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<InscricaoDTO, Inscricao>()
                .ForPath(dest => dest.Candidato.Id, opt => opt.MapFrom(src => src.CandidatoId))
                .ForPath(dest => dest.Oferta.Id, opt => opt.MapFrom(src => src.OfertaId))
                .ForPath(dest => dest.ProcessoSeletivo.Id, opt => opt.MapFrom(src => src.ProcessoSeletivoId));

            CreateMap<Inscricao, InscricaoDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<Inscricao, InscricaoDTO>()
                .ForPath(dest => dest.CandidatoId, opt => opt.MapFrom(src => src.Candidato.Id))
                .ForPath(dest => dest.OfertaId, opt => opt.MapFrom(src => src.Oferta.Id))
                .ForPath(dest => dest.ProcessoSeletivoId, opt => opt.MapFrom(src => src.ProcessoSeletivo.Id));
            
            CreateMap<InscricaoUpdateDTO, Inscricao>()
                .ForMember(dest => dest.NumeroInscricao, opt => opt.PreCondition(src => src.NumeroInscricao.HasValue))
                .ForMember(dest => dest.Data, opt => opt.PreCondition(src => src.Data.HasValue))
                .ForMember(dest => dest.Status, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Status.ToString())))
                .ForMember(dest => dest.Candidato, opt => opt.Ignore())
                .ForMember(dest => dest.ProcessoSeletivo, opt => opt.Ignore())
                .ForMember(dest => dest.Oferta, opt => opt.Ignore());
                

            CreateMap<OfertaDTO, Oferta>()
                .ForMember(dest => dest.Descricao, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Descricao?.ToString())))
                .ForMember(dest => dest.Nome, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Nome?.ToString())))
                .ForMember(dest => dest.VagasDisponiveis, opt => opt.PreCondition(src => src.VagasDisponiveis.HasValue))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProcessoSeletivoDTO, ProcessoSeletivo>()
                .ForMember(dest => dest.DataInicio, opt => opt.PreCondition(src => src.DataInicio.HasValue))
                .ForMember(dest => dest.DataTermino, opt => opt.PreCondition(src => src.DataTermino.HasValue))
                .ForMember(dest => dest.Nome, opt => opt.PreCondition(src => !string.IsNullOrEmpty(src.Nome?.ToString())))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}