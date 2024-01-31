using Api.Models;

namespace Api.Services
{
    public interface IBenefitService
    {
        decimal Calculate(Employee employee);
    }
}
