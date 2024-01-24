using Api.Dtos.Employee;
using Api.Models;

namespace Api.Services
{
    public interface IEmployeeService
    {
        IEnumerable<GetEmployeeDto> GetEmployees();
        GetEmployeeDto GetEmployeeByID(int id);
    }
}
