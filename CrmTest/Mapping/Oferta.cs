using AutoMapper;
using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Mapping
{
   public class OfertaAutoMapper : Profile
   {
       public OfertaAutoMapper()
       {
           CreateMap<OfertaDTO, Oferta>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
       }
   }

}