using AutoMapper;
using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Mapping{
    public class LeadAutoMapper : Profile
    {
        public LeadAutoMapper(){
            CreateMap<LeadDTO, Lead>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
        }
    }
}