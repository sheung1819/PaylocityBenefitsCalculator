using Api.Dtos.Employee;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class EmployeeService : BaseService,  IEmployeeService
    {        
        private readonly IEmployeeRepository _employeeRepository;       
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository) : base(mapper) 
        {        
            _employeeRepository = employeeRepository;       
        }
        public GetEmployeeDto? GetEmployeeByID(int id)
        {
            var result = _employeeRepository.GetEmployeeByID(id);    
            if (result == null) 
            {
                return null;
            }

            return MapToDot<GetEmployeeDto>(result);             
        }
        public IEnumerable<GetEmployeeDto> GetEmployees()
        {
            var result = _employeeRepository.GetEmployees();
            return MapToDot<IEnumerable<GetEmployeeDto>>(result);       
        }
    }
}
