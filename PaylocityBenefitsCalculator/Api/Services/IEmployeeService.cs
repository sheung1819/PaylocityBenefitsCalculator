using Api.Dtos.Employee;

namespace Api.Services
{
    public interface IEmployeeService
    {
        IEnumerable<GetEmployeeDto> GetEmployees();
        GetEmployeeDto? GetEmployeeByID(int id);        
    }
}
