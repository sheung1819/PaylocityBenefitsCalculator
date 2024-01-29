using Api.Dtos.Employee;
using Api.Dtos.MonthlyPaycheck;

namespace Api.Dtos.Paycheck
{
    public class GetPaycheckDto
    {
        public GetEmployeeDto Employee { get; set; } = new GetEmployeeDto();
        public decimal TotalBenefitCost { get; set; }
        public IList<GetMonthyPaycheckDto> MonthlyPaychecks { get; set; } = new List<GetMonthyPaycheckDto>();
    }
}