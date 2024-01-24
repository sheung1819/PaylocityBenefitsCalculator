using Api.Dtos.Employee;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository) 
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public GetEmployeeDto GetEmployeeByID(int id)
        {
            var result = _employeeRepository.GetEmployeeByID(id);    
            return _mapper.Map<GetEmployeeDto>(result);
        }

        public IEnumerable<GetEmployeeDto> GetEmployees()
        {
            var result = _employeeRepository.GetEmployees();
            return _mapper.Map<IEnumerable<GetEmployeeDto>>(result);
        }
    }
}
