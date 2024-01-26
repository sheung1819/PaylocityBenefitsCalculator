using Api.Dtos.Employee;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBenefitService _benefitService;    
        private readonly IMonthlyPaycheckCalculator _monthlyPaycheckCalculator;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository, IBenefitService benefitService, IMonthlyPaycheckCalculator monthlyPaycheckCalculator) 
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _benefitService = benefitService;
            _monthlyPaycheckCalculator = monthlyPaycheckCalculator;
        }
        public GetEmployeeDto? GetEmployeeByID(int id)
        {
            var result = _employeeRepository.GetEmployeeByID(id);    
            if (result == null) 
            {
                return null;
            }
            return _mapper.Map<GetEmployeeDto>(result);
        }
        public IEnumerable<GetEmployeeDto> GetEmployees()
        {
            var result = _employeeRepository.GetEmployees();
            return _mapper.Map<IEnumerable<GetEmployeeDto>>(result);
        }
        public GetEmployeeDto? CalculateBenefit(int id) 
        {
            var employee = _employeeRepository.GetEmployeeByID(id);
            if (employee == null)
            {
                return null;
            }

          
        }
    }
}
