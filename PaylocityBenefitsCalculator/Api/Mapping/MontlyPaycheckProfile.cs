using Api.Dtos.MonthlyPaycheck;
using Api.Models;
using AutoMapper;

namespace Api.Mapping
{
    public class MontlyPaycheckProfile : Profile
    {
        public MontlyPaycheckProfile()
        {
            CreateMap<GetMonthlyPaycheckDto, MonthlyPaycheck>().ReverseMap();
        }
    }
}
