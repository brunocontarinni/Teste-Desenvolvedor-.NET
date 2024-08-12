using AutoMapper;
using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Mapping
{
    public class ProcessoSeletivoAutoMapper : Profile
    {
        public ProcessoSeletivoAutoMapper()
        {
            CreateMap<ProcessoSeletivoDTO, Oferta>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }

}