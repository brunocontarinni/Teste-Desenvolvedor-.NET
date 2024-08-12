using AutoMapper;
using Inscricoes.Domain.Entities;
using Inscricoes.Application.DTOs.Inscricao;
using Inscricoes.Application.DTOs.Lead;
using Inscricoes.Application.DTOs.Oferta;
using Inscricoes.Application.DTOs.ProcessoSeletivo;

namespace Inscricoes.Application.Mapper;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		// Lead Mappings
		CreateMap<Lead, CreateLeadRequestDTO>().ReverseMap();
		CreateMap<Lead, DetailLeadResponseDTO>();
		CreateMap<Lead, UpdateLeadRequestDTO>().ReverseMap();
		CreateMap<Lead, UpdateLeadResponseDTO>();
		CreateMap<Lead, DeleteLeadResponseDTO>();

		// Inscricao Mappings
		CreateMap<Inscricao, CreateInscricaoRequestDTO>().ReverseMap();
		CreateMap<Inscricao, CreateInscricaoResponseDTO>();
		CreateMap<Inscricao, DetailInscricaoResponseDTO>();
		CreateMap<Inscricao, UpdateInscricaoRequestDTO>().ReverseMap();
		CreateMap<Inscricao, UpdateInscricaoResponseDTO>();
		CreateMap<Inscricao, DeleteInscricaoResponseDTO>();
		CreateMap<Inscricao, DetailInscricaoProcessoResponseDTO>()
			.ForMember(dest => dest.ProcessoSeletivo, opt => opt.MapFrom(src => src.ProcessoSeletivo));

		// ProcessoSeletivo Mappings
		CreateMap<ProcessoSeletivo, CreateProcessoSeletivoRequestDTO>().ReverseMap();
		CreateMap<ProcessoSeletivo, DetailProcessoSeletivoResponseDTO>();
		CreateMap<ProcessoSeletivo, UpdateProcessoSeletivoRequestDTO>().ReverseMap();
		CreateMap<ProcessoSeletivo, UpdateProcessoSeletivoResponseDTO>();
		CreateMap<ProcessoSeletivo, DeleteProcessoSeletivoResponseDTO>();

		// Oferta Mappings
		CreateMap<Oferta, CreateOfertaRequestDTO>().ReverseMap();
		CreateMap<Oferta, DetailOfertaResponseDTO>();
		CreateMap<Oferta, UpdateOfertaRequestDTO>().ReverseMap();
		CreateMap<Oferta, UpdateOfertaResponseDTO>();
		CreateMap<Oferta, DeleteOfertaResponseDTO>();
	}
}
