using Api.Dtos.Dependent;
using Api.Models;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class DependentService : IDependentService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public DependentService(IMapper mapper, IEmployeeRepository employeeRepository) 
        {
            _mapper = mapper;
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
            return _mapper.Map<GetDependentDto>(dependent);
        }

        public IEnumerable<GetDependentDto> GetDependents()
        {
            var employees = _employeeRepository.GetEmployees();
            var dependents = employees.SelectMany(x => x.Dependents);
            return _mapper.Map<IEnumerable<GetDependentDto>>(dependents);
        }
    }
}
