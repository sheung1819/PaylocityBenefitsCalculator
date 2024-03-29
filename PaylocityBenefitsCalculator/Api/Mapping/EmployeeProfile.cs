﻿using Api.Dtos.Employee;
using Api.Models;
using AutoMapper;

namespace Api.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<GetEmployeeDto, Employee>().ReverseMap();            
        }
    }
}
