using Api.Dtos.Employee;

namespace Api.Services
{
    public interface IEmployeeBenefitService
    {
        GetEmployeeDto? CalculateBenefit(int employeeId);
    }
}
