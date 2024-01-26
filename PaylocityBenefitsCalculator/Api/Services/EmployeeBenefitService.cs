using Api.Dtos.Employee;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    public class EmployeeBenefitService : IEmployeeBenefitService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBenefitService _benefitService;
        private readonly IMonthlyPaycheckCalculator _monthlyPaycheckCalculator;
        private readonly IMapper _mapper;

        public EmployeeBenefitService(IMapper mapper, IEmployeeRepository employeeRepository, IBenefitService benefitService, IMonthlyPaycheckCalculator monthlyPaycheckCalculator) 
        {
            _employeeRepository = employeeRepository;
            _benefitService = benefitService;
            _monthlyPaycheckCalculator = monthlyPaycheckCalculator;
            _mapper = mapper;
        }
        public GetEmployeeDto? CalculateBenefit(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeByID(employeeId);

            if(employee == null) 
            {
                return null;
            }

            var benefitCost = _benefitService.Calculate(employee);

            var monthlyBenefitCost = _monthlyPaycheckCalculator.Calculate(benefitCost);
            var monthlySalary = _monthlyPaycheckCalculator.Calculate(employee.Salary);

            for (var i = 0; i < monthlyBenefitCost.Count - 1; i++)
            {
                employee.Paychecks.Add(new Models.MonthlyPaycheck()
                {
                    BenefitCost = monthlyBenefitCost[i],
                    Salary = monthlySalary[i]
                });
            }

            return _mapper.Map<GetEmployeeDto>(employee);
        }
    }
}
