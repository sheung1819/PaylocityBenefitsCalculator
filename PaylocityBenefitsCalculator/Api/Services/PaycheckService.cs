using Api.Models;
using Api.Repositories;
using AutoMapper;

namespace Api.Services
{
    
    public class PaycheckService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBenefitService _benefitService;
        private readonly IMonthlyPaycheckCalculator _monthlyPaycheckCalculator;
        public PaycheckService(IMapper mapper, IEmployeeRepository employeeRepository, IBenefitService benefitService, IMonthlyPaycheckCalculator monthlyPaycheckCalculator) 
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _benefitService = benefitService;
            _monthlyPaycheckCalculator = monthlyPaycheckCalculator; 
        }
        public Paycheck? CalculateMonthlyPaycheck(int employeeId)
        { 
            var employee = _employeeRepository.GetEmployeeByID(employeeId); 

            if(employee == null) 
            {
                return null;
            }

            var benefitCost = _benefitService.Calculate(employee);

            var paycheck = new Paycheck
            {
                TotalBenefitCost = benefitCost,
                Employee = employee
            };
           
            _monthlyPaycheckCalculator.Calculate(paycheck);

            return paycheck;
        }
    }
}
