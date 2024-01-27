using Api.Dtos.Dependent;
using Api.Models;
using Api.Repositories;
using AutoMapper;
using System.Collections.Generic;

namespace Api.Services
{
    public class DependentService : BaseService, IDependentService
    {        
        private readonly IEmployeeRepository _employeeRepository;
        public DependentService(IMapper mapper, IEmployeeRepository employeeRepository)  : base(mapper) 
        {     
            _employeeRepository = employeeRepository;   
        }

        public GetDependentDto? GetDependentByID(int id)
        {
            var employees = _employeeRepository.GetEmployees();
            var dependent = employees.SelectMany(x => x.Dependents).FirstOrDefault(x => x.Id == id);

            if(dependent == null) 
            {
                return null;
            }
            return MapToDot<GetDependentDto>(dependent);            
        }

        public IEnumerable<GetDependentDto> GetDependents()
        {
            var employees = _employeeRepository.GetEmployees();
            var dependents = employees.SelectMany(x => x.Dependents);
            return MapToDot<IEnumerable<GetDependentDto>>(dependents);
        }
    }
}
