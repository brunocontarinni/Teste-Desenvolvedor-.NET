using AutoMapper;
using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Mapping{
    public class InscricaoAutoMapper : Profile
    {
        public InscricaoAutoMapper()
        {
            CreateMap<InscricaoDTO, Inscricao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.N_inscricao, opt=> opt.Ignore());

        }
    }
}