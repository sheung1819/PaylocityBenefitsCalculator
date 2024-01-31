using Api.Dtos.Paycheck;
using Api.Models;
using AutoMapper;

namespace Api.Mapping
{
    public class PaycheckProfile : Profile
    {
        public PaycheckProfile()
        {
            CreateMap<GetPaycheckDto, Paycheck>().ReverseMap();
        }
    }
}
